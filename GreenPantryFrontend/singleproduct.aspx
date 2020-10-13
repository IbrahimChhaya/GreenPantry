<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="singleproduct.aspx.cs" Inherits="GreenPantryFrontend.singleproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Breadcrumb Section Begin -->
    <section class="breadcrumb-section set-bg" data-setbg="img/breadcrumb.jpg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="breadcrumb__text">
                        <h2 id="title" runat="server"></h2>
                        <div class="breadcrumb__option" id="productName" runat="server">
                            <a href="./index.html">Home</a>
                            <a href="./index.html">Vegetables</a>
                            <span>Vegetable’s Package</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb Section End -->

    <!-- Product Details Section Begin -->
    <section class="product-details spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-md-6">
                    <div class="product__details__pic">
                        <div class="product__details__pic__item" id="PImage" runat="server">
                            <img class="product__details__pic__item--large"
                                src="img/product/details/product-details-1.jpg" alt="">
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6" >
                    <div class="product__details__text" id="PDetails" runat="server">
                        <h3 runat="server" id="pName">Vetgetable’s Package</h3>
                        <div class="product__details__price" runat="server" id="pPrice">
                            R50.00
                        </div>
                    
                        <div class="product__details__quantity" >
                            <div class="quantity">
                                <div class="pro-qty">
                                    <input type="text" value="1" id="item_qty" runat="server" readonly>
                                </div>
                            </div>
                        </div>
<%--                        <form id="form1" runat="server">--%>
<%--                            <a href="/" class="primary-btn" runat="server" id="addToCart" onclick="add_Click">ADD TO CART</a>--%>
<%--                            <asp:button class="site-btn" ID="addToCart" runat="server" Text="ADD TO CART" OnClientClick="showConfirmation()" type="button"/>--%>
<%--                            <button class="site-btn" ID="addToCart" runat="server" Text="ADD TO CART" onserverclick="add_Click" type="button"/>--%>
                            <a class="site-btn" runat="server" id="addToCart" style="color:white; cursor: pointer">ADD TO CART</a>
    
                            <a class="heart-icon" id="listIcon" runat="server" ><span class="icon_ul iconSize"></span> Add to Shopping List</a>
<%--                         </form>--%>
                        <ul>
                            <li><b>Availability</b> <span id="stock" runat="server">In Stock</span></li>
                            <li><b>Share on</b>
                                <div class="share">
                                    <a href="https://www.facebook.com/sharer/sharer.php?u=greenpantry.me/singleproduct.aspx?ProductID=1"><i class="fa fa-facebook"></i></a>
                                    <a href="https://twitter.com/share?text=ProductName&url=greenpantry.me/singleproduct.aspx?ProductID=1"><i class="fa fa-twitter"></i></a>
                                    <a href="https://www.instagram.com/sharer/sharer.php?u=greenpantry.me/singleproduct.aspx?ProductID=1"><i class="fa fa-instagram"></i></a>
                                    <a href="https://pinterest.com/pin/create/button/?url=greenpantry.me/singleproduct.aspx?ProductID=1&media=productImage&description=productName"><i class="fa fa-pinterest"></i></a>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="product__details__tab">
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" data-toggle="tab" href="#tabs-1" role="tab"
                                    aria-selected="true">Description</a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tabs-1" role="tabpanel">
                                <div class="product__details__tab__desc" id="Description" runat="server">
                                    <h6>Products Infomation</h6>
                                    <p>Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui.
                                        Pellentesque in ipsum id orci porta dapibus. Proin eget tortor risus. Vivamus
                                        suscipit tortor eget felis porttitor volutpat. Vestibulum ac diam sit amet quam
                                        vehicula elementum sed sit amet dui. Donec rutrum congue leo eget malesuada.
                                        Vivamus suscipit tortor eget felis porttitor volutpat. Curabitur arcu erat,
                                        accumsan id imperdiet et, porttitor at sem. Praesent sapien massa, convallis a
                                        pellentesque nec, egestas non nisi. Vestibulum ac diam sit amet quam vehicula
                                        elementum sed sit amet dui. Vestibulum ante ipsum primis in faucibus orci luctus
                                        et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam
                                        vel, ullamcorper sit amet ligula. Proin eget tortor risus.</p>
                                        <p>Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Lorem
                                        ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit aliquet
                                        elit, eget tincidunt nibh pulvinar a. Cras ultricies ligula sed magna dictum
                                        porta. Cras ultricies ligula sed magna dictum porta. Sed porttitor lectus
                                        nibh. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a.
                                        Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui. Sed
                                        porttitor lectus nibh. Vestibulum ac diam sit amet quam vehicula elementum
                                        sed sit amet dui. Proin eget tortor risus.</p>
                                </div>
                            </div>
                          
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Product Details Section End -->

    <!-- Related Product Section Begin -->
    <section class="related-product">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="section-title related__product__title">
                        <h2>Related Product</h2>
                    </div>
                </div>
            </div>
            <div class="row" id="RelatedProducts" runat="server">
                <div class="col-lg-3 col-md-4 col-sm-6">
                    <div class="product__item">
                        <div class="product__item__pic set-bg" data-setbg="img/product/product-1.jpg">
                            <ul class="product__item__pic__hover">
                                <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                            </ul>
                        </div>
                        <div class="product__item__text">
                            <h6><a href="#">Crab Pool Security</a></h6>
                            <h5>$30.00</h5>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6">
                    <div class="product__item">
                        <div class="product__item__pic set-bg" data-setbg="img/product/product-2.jpg">
                            <ul class="product__item__pic__hover">
                                <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                            </ul>
                        </div>
                        <div class="product__item__text">
                            <h6><a href="#">Crab Pool Security</a></h6>
                            <h5>$30.00</h5>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6">
                    <div class="product__item">
                        <div class="product__item__pic set-bg" data-setbg="img/product/product-3.jpg">
                            <ul class="product__item__pic__hover">
                                <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                            </ul>
                        </div>
                        <div class="product__item__text">
                            <h6><a href="#">Crab Pool Security</a></h6>
                            <h5>$30.00</h5>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6">
                    <div class="product__item">
                        <div class="product__item__pic set-bg" data-setbg="img/product/product-7.jpg">
                            <ul class="product__item__pic__hover">
                                <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                            </ul>
                        </div>
                        <div class="product__item__text">
                            <h6><a href="#">Crab Pool Security</a></h6>
                            <h5>$30.00</h5>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Related Product Section End -->

    <script>

        document.getElementById('ContentPlaceHolder1_addToCart').addEventListener("click", function (event) {
            event.preventDefault()
            var added = <%= add_Click()%>;
            if (added > 0) {
                showConfirmation("Successfully added to cart")
            }
            else {
                showError("Could not add to cart")
            }
           
        });

        document.getElementById('ContentPlaceHolder1_listIcon').addEventListener("click", function (event) {
            event.preventDefault()
            var addedToList = <%= listIcon_ServerClick()%>;

            if (addedToList == 0) {
                showWarning("This item is already in your list")
            }
            else if (addedToList == 1) {
                showConfirmation("Successfully added to list")
            }
            else {
                showError("Could not add to list")
            }

        });

        function showConfirmation(message) {
            var myToast = new Toastify({
                text: message,
                duration: 1500,
                backgroundColor: "#0FAB2C",
                close: true
            }).showToast();
        }

        function showError(message) {
            var myToast = new Toastify({
                text: message,
                duration: 1500,
                backgroundColor: "#dc3545",
                close: true
            }).showToast();
        }

        function showWarning(message) {
            var myToast = new Toastify({
                text: message,
                duration: 2000,
                backgroundColor: "#f5dd29",
                close: true,
                opacity: 10
            }).showToast();
        }
        
    </script>
    </asp:Content>

