using System;
using System.Collections.Generic;
using MovilVentas.Api.Dtos;

namespace MovilVentas.Api.Interfaces
{
    public interface IClienteService
    { 
        List<ClienteDto> Get();
        ClienteDto Get(int Id);
        ClienteDto Create(ClienteDto entity);
        void Update(int Id, ClienteDto entity);
        void Delete(int Id); 
    }
}
