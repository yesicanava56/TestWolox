using System;

namespace Test.Wolox.Models
{
    public class UserViewModel
    {
       
    }
    public class Enumerators
    {
        public enum StoragePermissions
        {
            Private = 0,
            PublicRead = 1,
            PublicWrite = 2
        }

        public enum OrderStatus
        {
            Asignado = 35,
            Entregado = 60,
            EnProcesoDeEnvio = 170,
        }

        public enum OrderTypes
        {
            Mixed = 30,
            MarketPlace = 80
        }

        public enum ProductStatus
        {
            Asignado = 35,
            AprobadoDespacho = 45,
            Cancelado = 80,
            Empacado = 47,
            EnProcesoDeEnvio = 170,
            Entregado = 60,
            FacturadoEnviado = 50,
            PagadoCancelado = 120,
            RechazadoDespacho = 55,
            SinInventario = 185,
            SinInventarioNotificado = 185
        }

        public enum QueryEnumerator
        {
            Equal = 0,
            LessThanOrEqual = 1,
            LessThan = 2,
            GreaterThanOrEqual = 3,
            GreaterThan = 4,
            BeginsWith = 5,
            Between = 6
        }

        public enum QueryScanOperator
        {
            Equal = 0,
            NotEqual = 1,
            LessThanOrEqual = 2,
            LessThan = 3,
            GreaterThanOrEqual = 4,
            GreaterThan = 5,
            IsNotNull = 6,
            IsNull = 7,
            Contains = 8,
            NotContains = 9,
            BeginsWith = 10,
            In = 11,
            Between = 12
        }

        public enum ReversionRequestStatus
        {
            Create = 1,
            Approved = 2,
            Rejected = 3,
            RejectedSeller = 4,
            AcceptedSeller = 5,
            RejectedSellerApproved = 6,
            RejectedSellerRejected = 7,
            AcceptedAutomatically = 8,
            ReceiptPending = 9,
            ReceiptRejectedSeller = 10,
            ReceiptAcceptedSeller = 11,
            RejectedReceiptRejectedSellerApproved = 12,
            RejectedReceiptRejectedSellerRejected = 13
        }

        public enum ReversionRequestRejectionType
        {
            ReversionRequest = 1,
            ReversionRequestMPSeller = 2,
            ReversionRequestMPSAC = 3,
            ReciveMPSeller = 4,
            ReciveMPSAC = 5
        }

        public enum ProductType
        {
            Invalid = 0,
            Grocery = 1,
            Technology = 2,
            Clothing = 3,
            Appliance = 4,
            PersonalCare = 5,
            Household = 6,
            GiftCard = 7,
            Stationery = 8,
            Warranty = 9,
            StationerySpecial = 10
        }

        public enum StatusLoad
        {
            Empty = 0,
            Processing = 1,
            Successful = 2,
            Error = 3,
            SentToSNS = 4
        }
    }
}
