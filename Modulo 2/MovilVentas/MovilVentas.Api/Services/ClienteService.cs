using System;
using System.Collections.Generic;
using System.Linq;
using MovilVentas.Api.Dtos;
using MovilVentas.Api.Interfaces;
using MovilVentas.Domain.Entities;
using MovilVentas.Infrastructure.Interfaces;

namespace MovilVentas.Api.Services
{
    public class ClienteService : IClienteService
    {
        public IClienteRepository ClienteRepository { get; set; }
        public ClienteService(IClienteRepository clienteRepository)
        {
            ClienteRepository = clienteRepository;
        }
        public ClienteDto Create(ClienteDto dto)
        {
            var entity = new ClienteEntity
            {
                Activo = dto.Activo,
                Apellidos = dto.Apellidos,
                Edad = dto.Edad,
                FechaNacimiento = dto.FechaNacimiento,
                Nombres = dto.Nombres
            };
            entity.CalcularComision();


            var newEntity = ClienteRepository.Create(entity);


            dto.Id = newEntity.Id;


            return dto;
        }

        public void Delete(int Id)
        {
            ClienteRepository.Delete(Id);
        }

        public List<ClienteDto> Get()
        {
            var list = ClienteRepository.Get();
            return list.Select(client => new ClienteDto
            {
                Activo = client.Activo,
                Nombres = client.Nombres,
                Apellidos = client.Apellidos,
                Edad = client.Edad,
                Id = client.Id

            }).ToList();

        }

        public ClienteDto Get(int Id)
        {
            var client = ClienteRepository.Get(Id);
            return new ClienteDto
            {
                Activo = client.Activo,
                Nombres = client.Nombres,
                Apellidos = client.Apellidos,
                Edad = client.Edad,
                Id = client.Id
            };
        }

        public void Update(int Id, ClienteDto dto)
        {
            var entity = new ClienteEntity
            {
                Id = dto.Id,
                Activo = dto.Activo,
                Apellidos = dto.Apellidos,
                Edad = dto.Edad,
                FechaNacimiento = dto.FechaNacimiento,
                Nombres = dto.Nombres
            };
            entity.CalcularComision();

            ClienteRepository.Update(Id, entity);
        }
    }
}
