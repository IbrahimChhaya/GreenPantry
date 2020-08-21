<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="GreenPantryFrontend.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Hero Section Begin -->
    <section class="hero">
        <div class="container">
            <div class="row">
                <div class="col-lg-3">
                    <div class="hero__categories">
                        <div class="hero__categories__all">
                            <i class="fa fa-bars"></i>
                            <span>All departments</span>
                        </div>
                        <ul id="categoryList" runat="server">
                            <li><a href="#">Fresh Meat</a></li>
                            <li><a href="#">Vegetables</a></li>
                            <li><a href="#">Fruit & Nut Gifts</a></li>
                            <li><a href="#">Fresh Berries</a></li>
                            <li><a href="#">Ocean Foods</a></li>
                            <li><a href="#">Butter & Eggs</a></li>
                            <li><a href="#">Fastfood</a></li>
                            <li><a href="#">Fresh Onion</a></li>
                            <li><a href="#">Papayaya & Crisps</a></li>
                            <li><a href="#">Oatmeal</a></li>
                            <li><a href="#">Fresh Bananas</a></li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-9">
                    <div class="hero__search">
                        <div class="hero__search__form">
                            <form action="#">
                                <div class="hero__search__categories">
                                    All Categories
                                    <span class="arrow_carrot-down"></span>
                                </div>
                                <input type="text">
                                <button type="submit" class="site-btn">SEARCH</button>
                            </form>
                        </div>
                        <div class="hero__search__phone">
                            <div class="hero__search__phone__icon">
                                <i class="fa fa-phone"></i>
                            </div>
                            <div class="hero__search__phone__text">
                                <h5><a href="tel:0116168269">011 616 8269</a></h5>
                                <span>support 24/7 time</span>
                            </div>
                        </div>
                    </div>
                 <!-- Banner Begin -->
                    <div class="banner">
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="hero__4item set-bg" data-setbg="img/banner/banner-1.jpg">
                                        <div class="hero__textButBlack">
                                            <span></span>
                                            <h2>Zeerak <br />Dumb</h2>
                                            <p>100% dumb</p>
                                            <a href="#" class="primary-btn">SHOP NOW</a>
                                        </div>
                                     </div>
                                    <!--<div class="banner__pic">
                                        <img src="img/banner/banner-1.jpg" alt="">
                                    </div>-->
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="banner__pic">
                                        <img src="img/banner/banner-2.jpg" alt="">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    </br>
                    <div class="banner">
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="banner__pic">
                                        <img src="img/banner/banner-1.jpg" alt="">
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="banner__pic">
                                        <img src="img/banner/banner-2.jpg" alt="">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Banner End -->
                </div>
            </div>
        </div>
    </section>
    <!-- Hero Section End -->

    <!-- Categories Section Begin -->
    <section class="categories">
        <div class="container">
            <div class="row" id="categorySlider1" runat="server">
                <div class="col-lg-12">
                    <div class="hero__item set-bg" data-setbg="img/freeshipping.png">
                        <div class="hero__text">
                            <span></span>
                            <h2>Free <br />Shipping</h2>
                            <p>On Orders Over R500</p>
                            <a href="#" class="primary-btn">SHOP NOW</a>
                        </div>
                    </div>

                    </br>

                    <div class="section-title">
                        <h2>Freshly Picked</h2>
                    </div>
                </div>
                <div class="categories__slider owl-carousel">
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/categories/cat-1.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                       </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/categories/cat-2.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                       </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/categories/cat-3.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                       </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/featured/feature-1.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                       </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/categories/cat-5.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Categories Section End -->

    <!-- Categories Section Begin 2 -->
    <section class="categories">
        <div class="container">
            <div class="row" id="categorySlider2" runat="server">
                <div class="col-lg-12">
                    <div class="section-title">
                        <h2>Fresh From The Bakery</h2>
                    </div>
                </div>
                <div class="categories__slider owl-carousel">
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/categories/cat-1.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                       </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/categories/cat-2.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                       </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/categories/cat-3.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                       </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/featured/feature-1.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                       </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/categories/cat-5.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Categories Section 2 End -->

    <!-- Categories Section Begin 3 -->
    <section class="categories">
        <div class="container">
            <div class="row" id="categorySlider3" runat="server">
                <div class="col-lg-12">
                    <div class="section-title">
                        <h2>Baby products for Zeerak</h2>
                    </div>
                </div>
                <div class="categories__slider owl-carousel">
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/categories/cat-1.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                       </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/categories/cat-2.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                       </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/categories/cat-3.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                       </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/featured/feature-1.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                       </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/categories/cat-5.jpg">
                                <ul class="featured__item__pic__hover">
                                    <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                    <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                    <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                                </ul>
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Crab Pool Security</a></h6>
                                <h5>$30.00</h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Categories Section 3 End -->

    <!-- Banner Begin -->
    <div class="banner">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="banner__pic">
                        <img src="img/banner/banner-1.jpg" alt="">
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="banner__pic">
                        <img src="img/banner/banner-2.jpg" alt="">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Banner End -->
    </br>

 </asp:Content>