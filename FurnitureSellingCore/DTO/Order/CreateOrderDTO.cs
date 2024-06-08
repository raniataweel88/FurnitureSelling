namespace FurnitureSellingCore.DTO.Order
{
    public class CreateOrderDTO
    {

        public string  Title { get; set; }
        public DateTime Date { get; set; }  
        public string?  CustomerNote { get; set; }
        //public float TotalPrice { get; set; }
      
       // public float Fee { get; set; }
     
    }
}