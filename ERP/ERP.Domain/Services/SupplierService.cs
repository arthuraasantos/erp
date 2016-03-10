﻿using ERP.Domain.Entities;

namespace ERP.Domain.Services
{

    public static class SupplierService
    {
        public static bool IsValid(Supplier entity) => VerifyRequiredField(entity);

        private static bool VerifyRequiredField(Supplier entity)
        {
            if (string.IsNullOrWhiteSpace(entity.CpfCnpj.ToString())) return false;
            if (string.IsNullOrWhiteSpace(entity.RegistrationName)) return false;
            if (string.IsNullOrWhiteSpace(entity.Name)) return false;
            if (string.IsNullOrWhiteSpace(entity.FantasyName)) return false;
            if (entity.Address != null) return false;

            return true;
        }

        public static bool IsActive(Supplier entity) => entity.DeleteDate != null;
    }
}
