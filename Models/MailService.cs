using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Models.Framework;

namespace Models
{
    public class MailService
    {
        public StringBuilder MailOrder( Customer cus, Order order, List<PetShop.Models.CartItem> detail) {
            StringBuilder Body = new StringBuilder();
            Body.Append("<p>Cảm ơn quý khách đã sử dụng sản phẩm của chúng tôi, chúng tôi sẽ liên lạc lại cho quý khách trong thời gian sớm nhất:</p>");
            Body.Append("<table>");
            Body.Append("<tr><td colspan='2'><h4>Thông tin khách hàng</h4></td></tr>");
            Body.Append("<tr><td>Họ và tên:</td><td>"+cus.FirstName +" "+cus.LastName+"</td></tr>");
            Body.Append("<tr><td>Số điện thoại:</td><td>016446xxxx</td></tr>");
            Body.Append("<tr><td>Địa chỉ:</td><td>"+cus.Address+"</td></tr>");
            Body.Append("<tr><td>Email:</td><td>"+cus.Email+"</td></tr>");
            int sum=0;
            foreach(PetShop.Models.CartItem item in detail)
            {

                Body.Append("<tr><td>Sản Phẩm :</td><td> " + item.Product.Name + " SL:"+item.Quantity+" Đơn giá:"+item.Product.Price+"</td></tr>");
                sum += (int)(item.Quantity * item.Product.Price);

                
            }
            Body.Append("<tr><td><h4>Thành Tiền :</td><td> " + (Decimal)sum + " VND</h4></td></tr>");
            Body.Append("<tr><td>Nguồn khách:</td><td>OUPetShop.com</td></tr>");
            Body.Append("</table>");
            return Body;
        }
        public StringBuilder MailSignUp(string code)
        {
            StringBuilder Body = new StringBuilder();
            Body.Append("<p>Cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi xác nhận Email Vui lòng nhấn vào liên kết bên dưới</p>");
         
            Body.Append("<a href='"+"http://localhost:54170/CofirmAccCus?code="+code+"' >http://localhost:54170/CofirmAccCus?code=" + code+"</a>");
            return Body;
        }
        public void SendMail(StringBuilder Body,string address)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(address);
            mail.From = new MailAddress("mailchatbot0099@gmail.com");
            mail.Subject = "OU Pet Shop";
            mail.Body = Body.ToString();// phần thân của mail ở trên
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("mailchatbot0099@gmail.com", "Toan123456");// tài khoản Gmail của bạn
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }
    }
}
