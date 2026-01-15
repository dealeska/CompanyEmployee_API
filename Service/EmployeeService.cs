using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Dynamic;

namespace Service
{
        private void CheckUserAccess(Guid companyId, System.Security.Claims.ClaimsPrincipal user)
        {
            if (user.IsInRole("Administrator"))
                return;

            var userCompanyIdClaim = user.FindFirst("CompanyId")?.Value;
            if (userCompanyIdClaim == null || !Guid.TryParse(userCompanyIdClaim, out var userCompanyId) || userCompanyId != companyId)
            {
                throw new UnauthorizedAccessException("You do not have access to this company's data.");
            }
        }

    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<EmployeeDto> _dataShaper;
        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IDataShaper<EmployeeDto> dataShaper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }        

        private async Task CheckIfCompanyExistsAsync(Guid companyId, bool trackChanges)
        {
            var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
        }

        private async Task<Employee> GetEmployeeForCompanyAndCheckIfItExistsAsync(Guid companyId, Guid id, bool trackChanges)
        {
        public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, System.Security.Claims.ClaimsPrincipal user, bool trackChanges)
            if (employeeDb is null)
            CheckUserAccess(companyId, user);
                throw new EmployeeNotFoundException(id);
            return employeeDb;
        }

        public async Task<(IEnumerable<ExpandoObject> employees, MetaData metaData)> GetEmployeesAsync(Guid companyId,
            System.Security.Claims.ClaimsPrincipal user, EmployeeParameters employeeParameters, bool trackChanges)
        {
            if (!employeeParameters.ValidAgeRange)
                throw new MaxAgeRangeBadRequestException();

            CheckUserAccess(companyId, user);
            await CheckIfCompanyExistsAsync(companyId, trackChanges);

            var employeesWithMetaData = await _repository.Employee.GetEmployeesAsync(companyId, employeeParameters, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);
            var shapedData = _dataShaper.ShapeData(employeesDto, employeeParameters.Fields);
            return (employees: shapedData, metaData: employeesWithMetaData.MetaData);
        }

        public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await CheckIfCompanyExistsAsync(companyId, trackChanges);

            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExistsAsync(companyId, id, trackChanges);

            var employee = _mapper.Map<EmployeeDto>(employeeDb);
            return employee;

        }

        public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreation,
            System.Security.Claims.ClaimsPrincipal user, bool trackChanges)
        {
            CheckUserAccess(companyId, user);
            await CheckIfCompanyExistsAsync(companyId, trackChanges);

            var employeeEntity = _mapper.Map<Employee>(employeeForCreation);

            _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            await _repository.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeToReturn;
        }

        public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, System.Security.Claims.ClaimsPrincipal user, bool trackChanges)
        {
            CheckUserAccess(companyId, user);
            await CheckIfCompanyExistsAsync(companyId, trackChanges);

            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExistsAsync(companyId, id, trackChanges);

            _repository.Employee.DeleteEmployee(employeeDb);
            await _repository.SaveAsync();
        }

        public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate,
            System.Security.Claims.ClaimsPrincipal user, bool compTrackChanges, bool empTrackChanges)
        {
            CheckUserAccess(companyId, user);
            await CheckIfCompanyExistsAsync(companyId, compTrackChanges);
            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExistsAsync(companyId, id, empTrackChanges);

            _mapper.Map(employeeForUpdate, employeeDb);
            await _repository.SaveAsync();

        }

        public async Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(Guid companyId,
            Guid id, System.Security.Claims.ClaimsPrincipal user, bool compTrackChanges, bool empTrackChanges)
        {
            CheckUserAccess(companyId, user);
            await CheckIfCompanyExistsAsync(companyId, compTrackChanges);
            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExistsAsync(companyId, id, empTrackChanges);

            var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeDb);
            return (employeeToPatch, employeeDb);
        }

        public async Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
        {
            _mapper.Map(employeeToPatch, employeeEntity);
            await _repository.SaveAsync();
        }
    }
}
