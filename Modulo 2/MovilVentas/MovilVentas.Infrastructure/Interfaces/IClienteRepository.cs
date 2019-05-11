using System;
using System.Collections;
using System.Collections.Generic;
using MovilVentas.Domain.Entities;

namespace MovilVentas.Infrastructure.Interfaces
{
    public interface IClienteRepository
    {
        IList<ClienteEntity> Get();
        ClienteEntity Get(int Id);
        ClienteEntity Create(ClienteEntity entity);
        void Update(int Id, ClienteEntity entity);
        void Delete(int Id);
    }
}
