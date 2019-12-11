using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_WAD.Models;

namespace Assignment_WAD.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        private static string SHOPPING_CART_NAME = "shoppingCart";
        private Assignment_WADContext db = new Assignment_WADContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCart(int productId, int quantity)
        {
            // Check số lượng có hợp lệ không?
            if (quantity <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Quantity");
            }
            // Check sản phẩm có hợp lệ không?
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's' not found");
            }
            // Lấy thông tin shopping cart từ session.
            var sc = LoadShoppingCart();
            // Thêm sản phẩm vào shopping cart.
            sc.AddCart(product, quantity);
            // lưu thông tin cart vào session.
            SaveShoppingCart(sc);
            return Redirect("/ShoppingCart/ShowCart");
        }

        public ActionResult UpdateCart(int productId, int quantity)
        {
            // Check số lượng có hợp lệ không?
            if (quantity <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Quantity");
            }
            // Check sản phẩm có hợp lệ không?
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's' not found");
            }
            // Lấy thông tin shopping cart từ session.
            var sc = LoadShoppingCart();
            // Thêm sản phẩm vào shopping cart.
            sc.UpdateCart(product, quantity);
            // lưu thông tin cart vào session.
            SaveShoppingCart(sc);
            return Redirect("/ShoppingCart/ShowCart");
        }

        public ActionResult RemoveCart(int productId)
        {
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's' not found");
            }
            // Lấy thông tin shopping cart từ session.
            var sc = LoadShoppingCart();
            // Thêm sản phẩm vào shopping cart.
            sc.RemoveFromCart(product.Id);
            // lưu thông tin cart vào session.
            SaveShoppingCart(sc);
            return Redirect("/ShoppingCart/ShowCart");
        }

        public ActionResult ShowCart()
        {
            ViewBag.shoppingCart = LoadShoppingCart();
            return View();
        }

        public ActionResult CreateOrder()
        {
            // load cart trong session.
            var shoppingCart = LoadShoppingCart();
            if (shoppingCart.GetCartItems().Count <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad request");
            }
            // chuyển thông tin shopping cart thành Order.
            var order = new Order
            {
                TotalPrice = shoppingCart.GetTotalPrice(),
                MemberId = 1,
                PaymentTypeId = (int)Order.PaymentType.Cod,
                ShipName = "Xuan Hung",
                ShipPhone = "0912345678",
                ShipAddress = "Ton That Thuyet",
                OrderDetails = new List<OrderDetail>()
            };
            // Tạo order detail từ cart item.
            foreach (var cartItem in shoppingCart.GetCartItems())
            {
                var orderDetail = new OrderDetail()
                {
                    ProductId = cartItem.Value.ProductId,
                    OrderId = order.Id,
                    Quantity = cartItem.Value.Quantity,
                    UnitPrice = cartItem.Value.Price
                };
                order.OrderDetails.Add(orderDetail);
            }
            db.Orders.Add(order);
            db.SaveChanges();
            ClearCart();
            //// lưu vào database.
            //var transaction = db.Database.BeginTransaction();
            //try
            //{

            //    transaction.Commit();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    transaction.Rollback();
            //}
            return Redirect("/Products");
        }

        private void ClearCart()
        {
            Session.Remove(SHOPPING_CART_NAME);
        }

        /**
         * Tham số nhận vào là một đối tượng shopping cart.
         * Hàm sẽ lưu đối tượng vào session với key được define từ trước.
         */
        private void SaveShoppingCart(ShoppingCart shoppingCart)
        {
            Session[SHOPPING_CART_NAME] = shoppingCart;
        }

        /**
         * Lấy thông tin shopping cart từ trong session ra. Trong trường hợp không tồn tại
         * trong session thì tạo mới đối tượng shopping cart.
         */
        private ShoppingCart LoadShoppingCart()
        {
            // lấy thông tin giỏ hàng ra.
            if (!(Session[SHOPPING_CART_NAME] is ShoppingCart sc))
            {
                sc = new ShoppingCart();
            }
            return sc;
        }
    }
}