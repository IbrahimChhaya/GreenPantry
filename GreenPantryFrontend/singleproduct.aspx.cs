using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class singleproduct : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            //dynamic getProducts = SC.getAllProducts(); 
            string Display = "";


                       //PImage
                       //            <img class="product__details__pic__item--large"
                       //                src="img/product/details/product-details-1.jpg" alt="">


            //Pdetails
            //< h3 > Vetgetable’s Package</ h3 >

            //              < div class="product__details__price" >R50.00</div>
            //            <div class="product__details__quantity" >
            //                <div class="quantity">
            //                    <div class="pro-qty">
            //                        <input type = "text" value="1">
            //                    </div>
            //                </div>
            //            </div>
            //            <a href = "#" class="primary-btn">ADD TO CART</a>
            //            <a href = "#" class="heart-icon"><span class="icon_heart_alt"></span></a>
            //            <ul>
            //                <li><b>Availability</b> <span>In Stock</span></li>
            //                <li><b>Share on</b>
            //                    <div class="share">
            //                        <a href = "#" >< i class="fa fa-facebook"></i></a>
            //                        <a href = "#" >< i class="fa fa-twitter"></i></a>
            //                        <a href = "#" >< i class="fa fa-instagram"></i></a>
            //                        <a href = "#" >< i class="fa fa-pinterest"></i></a>
            //                    </div>
            //                </li>
            //            </ul>



            //description
            //< h6 > Products Infomation </ h6 >
            //                           < p > Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui.
            //                                  Pellentesque in ipsum id orci porta dapibus.Proin eget tortor risus. Vivamus
            //                                 suscipit tortor eget felis porttitor volutpat.Vestibulum ac diam sit amet quam
            //                            vehicula elementum sed sit amet dui. Donec rutrum congue leo eget malesuada.
            //                            Vivamus suscipit tortor eget felis porttitor volutpat.Curabitur arcu erat,
            //                            accumsan id imperdiet et, porttitor at sem. Praesent sapien massa, convallis a
            //                            pellentesque nec, egestas non nisi. Vestibulum ac diam sit amet quam vehicula
            //                            elementum sed sit amet dui. Vestibulum ante ipsum primis in faucibus orci luctus
            //                            et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam
            //                            vel, ullamcorper sit amet ligula. Proin eget tortor risus.</ p >
            //                            < p > Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.Lorem
            //                               ipsum dolor sit amet, consectetur adipiscing elit.Mauris blandit aliquet
            //                              elit, eget tincidunt nibh pulvinar a. Cras ultricies ligula sed magna dictum
            //                            porta.Cras ultricies ligula sed magna dictum porta.Sed porttitor lectus
            //                            nibh.Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a.
            //                            Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui. Sed
            //                            porttitor lectus nibh. Vestibulum ac diam sit amet quam vehicula elementum
            //                            sed sit amet dui. Proin eget tortor risus.</ p >



                                        //relatedproducts
            //< div class="col-lg-3 col-md-4 col-sm-6">
            //        <div class="product__item">
            //            <div class="product__item__pic set-bg" data-setbg="img/product/product-1.jpg">
            //                <ul class="product__item__pic__hover">
            //                    <li><a href = "#" >< i class="fa fa-heart"></i></a></li>
            //                    <li><a href = "#" >< i class="fa fa-retweet"></i></a></li>
            //                    <li><a href = "#" >< i class="fa fa-shopping-cart"></i></a></li>
            //                </ul>
            //            </div>
            //            <div class="product__item__text">
            //                <h6><a href = "#" > Crab Pool Security</a></h6>
            //                <h5>$30.00</h5>
            //            </div>
            //        </div>
            //    </div>
        }

        private void saveToCookie(String CookieName, String content)
        {
            //content: productID-quantity,productID-quantity
            Response.Cookies[CookieName].Value += content + ",";
        }
        private void createCookie(String CookieName, String content)
        {
            Response.Cookies[CookieName].Value = content + ",";
        }

        private String readCookie(String CookieName)
        {
            return Request.Cookies[CookieName].ToString();
        }
    }
}