namespace FurnitureSellingCore.DTO.Order
{
    public class CreateOrderDTO
    {

        public string?  Title { get; set; }
        public DateTime Date { get; set; }  
        public string?  CustomerNote { get; set; }
        public string? CardNumber { get; set; }
        public string? Code { get; set; }
        public string? CardHolder { get; set; }
        public int Paymentmethod { get; set; }


    }
}