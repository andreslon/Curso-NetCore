using System;
using System.Collections.Generic;
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
                Activo= dto.Activo,
                Apellidos = dto.Apellidos,
                Edad = dto.Edad ,
                FechaNacimiento = dto.FechaNacimiento  ,
                Nombres = dto.Nombres 
            }; 
            entity.CalcularComision();


            var newEntity = ClienteRepository.Create(entity);


            dto.Id = newEntity.Id;


            return  dto;
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<ClienteDto> Get()
        {
            throw new NotImplementedException();
        }

        public ClienteDto Get(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, ClienteDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
