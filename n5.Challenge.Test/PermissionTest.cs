using AutoMapper;
using Moq;
using n5.Challenge.Application.Commands.AddPermission;
using n5.Challenge.Application.Commands.UpdatePermission;
using n5.Challenge.Application.Dto;
using n5.Challenge.Application.Queries.GetAllPermission;
using n5.Challenge.Application.Repositories;
using n5.Challenge.Application.UnitOfWork;
using n5.Challenge.Domain.Entities;
using Nest;

namespace n5.Challenge.Test
{
    public class PermissionTest
    {
        private readonly Mock<IUnitOfWork> unitOfWork;
        private readonly Mock<IPermissionRepository> permissionRepository;
        private readonly Mock<IElasticClient> elastic;
        private readonly Mock<IMapper> mapper;
        private readonly CancellationToken cancellationToken = CancellationToken.None;

        public PermissionTest()
        {
            unitOfWork = new Mock<IUnitOfWork>();
            permissionRepository = new Mock<IPermissionRepository>();
            unitOfWork.Setup(uow => uow.PermissionRepository).Returns(permissionRepository.Object);
            elastic = new Mock<IElasticClient>();
            mapper = new Mock<IMapper>();
        }
        [Fact]
        public async void AddPermission_ShouldAddPermissionSuccessfully()
        {
            var command = new AddPermissionCommand()
            {
                EmployeeName = "Andrés",
                EmployeeSurname = "Padillla",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 1
            };
            var handler = new AddPermissionCommandHandler(unitOfWork.Object, elastic.Object, mapper.Object);
            var response = await handler.Handle(command, cancellationToken);
            Assert.True(response);
        }

        [Fact]
        public async void AddPermission_ShouldConnectionDatabaseFail()
        {
            unitOfWork.Setup(uow => uow.CompleteAsync()).Throws(new Exception("Error database connection"));

            var command = new AddPermissionCommand()
            {
                EmployeeName = "Andrés",
                EmployeeSurname = "Padillla",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 1
            };
            var handler = new AddPermissionCommandHandler(unitOfWork.Object, elastic.Object, mapper.Object);
            var exception = await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, cancellationToken));
            Assert.Equal("Error database connection", exception.Message);
        }

        [Fact]
        public async void ModifyPermission_ShouldModifyPermissionSuccessfully()
        {
            var dateNow = DateTime.Now;
            var command = new UpdatePermissionCommand()
            {
                Id = 1,
                EmployeeName = "Andrés",
                EmployeeSurname = "Padillla",
                PermissionDate = dateNow,
                PermissionTypeId = 1
            };
            var permissionEntity = new Permission()
            {
                Id = 1,
                EmployeeName = "Andrés",
                EmployeeSurname = "Padillla",
                PermissionDate = dateNow,
                PermissionTypeId = 1
            };

            var permissionDto = new PermissionDto()
            {
                Id = 1,
                EmployeeName = "Andrés",
                EmployeeSurname = "Padillla",
                PermissionDate = dateNow,
                PermissionTypeId = 1,
                Description = "Admin"
            };

            mapper.Setup(m => m.Map<Permission>(It.IsAny<UpdatePermissionCommand>())).Returns(permissionEntity);
            mapper.Setup(m => m.Map<PermissionDto>(It.IsAny<Permission>())).Returns(permissionDto);

            var handler = new UpdatePermissionCommandHandler(unitOfWork.Object, elastic.Object, mapper.Object);
            var response = await handler.Handle(command, cancellationToken);
            Assert.Equal(response.EmployeeName, command.EmployeeName);
            Assert.Equal(response.EmployeeSurname, command.EmployeeSurname);
            Assert.Equal(response.PermissionDate, command.PermissionDate);
            Assert.Equal(response.PermissionTypeId, command.PermissionTypeId);
        }

        [Fact]
        public async void GetAllPermission_ShouldReturnListData()
        {


            var permissions = new List<Permission>
            {
                new() {
                    EmployeeName = "Andrés",
                    EmployeeSurname = "Padillla",
                    PermissionDate = DateTime.Now,
                    PermissionTypeId = 1
                },
                new() {
                    EmployeeName = "Andrés",
                    EmployeeSurname = "Padillla",
                    PermissionDate = DateTime.Now,
                    PermissionTypeId = 1
                }
            };

            var permissionDtos = new List<PermissionDto>
            {
                new() {
                    EmployeeName = "Andrés",
                    EmployeeSurname = "Padillla",
                    PermissionDate = DateTime.Now,
                    PermissionTypeId = 1,
                    Description = "Admin",
                },
                new() {
                    EmployeeName = "Andrés",
                    EmployeeSurname = "Padillla",
                    PermissionDate = DateTime.Now,
                    PermissionTypeId = 1,
                    Description = "Admin",
                }
            };

            permissionRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(permissions);

            unitOfWork.Setup(uow => uow.PermissionRepository).Returns(permissionRepository.Object);

            mapper.Setup(m => m.Map<IReadOnlyList<PermissionDto>>(permissions)).Returns(permissionDtos);

            var query = new GetAllPermissionQuery();
            var handler = new GetAllPermissionQueryHandler(unitOfWork.Object, mapper.Object);
            var response = await handler.Handle(query, cancellationToken);
            Assert.NotNull(response);
            Assert.Equal(2, response.Count);
        }

    }
}