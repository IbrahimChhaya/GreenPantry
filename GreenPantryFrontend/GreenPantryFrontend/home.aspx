﻿<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="GreenPantryFrontend.home" %>

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
                            <span>All Departments</span>
                        </div>
                        <ul id="categoryList" runat="server">
                            <li><a href="/categories.aspx?CategoryID=1">Fresh Meat</a></li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-9">
                    <div class="hero__search">
                        <div class="hero__search__form">
                            <form runat="server">
                                <div class="hero__search__categories">
                                    All Departments
                                    <span class="arrow_carrot-down"></span>
                                </div>
                                <input type="text" id="searchText" runat="server">
                                <button type="submit" class="site-btn" id="btnSearch" runat="server" onserverclick="btnSearch_Click">SEARCH</button>
                            </form>
                        </div>
                        <div class="hero__search__phone">
                            <div class="hero__search__phone__icon">
                                <i class="fa fa-user"></i>
                            </div>
                            <div class="hero__search__phone__text">
                                <!--<h5 id="myaccount" runat="server"><a href="login.aspx">Login / Register</a><span class="arrow_carrot-down"></span></h5>-->
                                <h5 id="account" runat="server"><a href="login.aspx">Login</a> / <a href="register2.aspx">Register</a></h5>
                            </div>
                        </div>
                    </div>
                 <!-- Banner Begin -->
                    <div class="banner">
                        <div class="container">
                          <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6" id="banner1" runat="server">
                                    <a href="#">
                                    <div class="hero__4item set-bg" data-setbg="img/banner/banner-1.png">
                                        <div class="hero__textButBlack">
                                            <span></span>
                                            <h2>Zeerak Dumb</h2>
                                            <p>100% dumb</p>
                                        </div>
                                     </div>
                                     </a>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6" id="banner2" runat="server">
                                <a href="#">
                                    <div class="hero__4item set-bg" data-setbg="img/banner/banner-2.png">
                                        <div class="hero__textButBlack secondary">
                                            <span></span>
                                            <h2>Ibrahim Dumb</h2>
                                            <p>100% dumb</p>
                                        </div>
                                    </div>
                                </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="banner">
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6" id="banner3" runat="server">
                                    <a href="#">
                                    <div class="hero__4item set-bg" data-setbg="img/banner/banner-3.png">
                                        <div class="hero__textButBlack secondary">
                                            <span></span>
                                            <h2>Zeerak Dumb</h2>
                                            <p>100% dumb</p>
                                        </div>
                                     </div>
                                    </a>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6" id="banner4" runat="server">
                                    <a href="#">
                                    <div class="hero__4item set-bg" data-setbg="img/banner/banner-4.png">
                                        <div class="hero__textButBlack">
                                            <span></span>
                                            <h2>Ibrahim Dumb</h2>
                                            <p>100% dumb</p>
                                        </div>
                                    </div>
                                    </a>
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

    <!-- Categories Section Begin 0-->
    <section class="categories">
        <div class="container">
            <div class="row" id="categorySlider" runat="server">
                <div class="col-lg-12">
                    <div class="hero__item set-bg" data-setbg="img/freeshipping.png">
                        <div class="hero__text">
                            <span></span>
                            <h2>Free <br />Shipping</h2>
                            <p>On Orders Over R500</p>
                            <a href="#" class="primary-btn">SHOP NOW</a>
                        </div>
                    </div>

                    <br />

                    <div class="section-title">
                        <h2>fwafawg Picked</h2>
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
                </div>
            </div>
        </div>
    </section>
    <!-- Categories Section End -->

    <!-- Categories Section Begin 1 -->
    <section class="categories" id="sectionToHide" runat="server" visible="false">
        <div class="container">
            <div class="row" id="categorySlider1" runat="server">
                <div class="col-lg-12">
                    <div class="section-title">
                        <h2> From The Bakery</h2>
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
                </div>
            </div>
        </div>
    </section>
    <!-- Categories Section 2 End -->

    <!-- Categories Section Begin 2 -->
    <section class="categories">
        <div class="container">
            <div class="row" id="categorySlider2" runat="server">
                <div class="col-lg-12">
                   <!-- <div class="hero__item set-bg" data-setbg="img/freeshipping.png">
                        <div class="hero__text">
                            <span></span>
                            <h2>Free <br />Shipping</h2>
                            <p>On Orders Over R500</p>
                            <a href="#" class="primary-btn">SHOP NOW</a>
                        </div>
                    </div>-->

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
                </div>
            </div>
        </div>
    </section>
    <!-- Categories Section 3 End -->
 <script>
     window.watsonAssistantChatOptions = {
         integrationID: "ea63b528-3949-469b-bb3d-b098b7956a85", // The ID of this integration.
         region: "eu-gb", // The region your integration is hosted in.
         serviceInstanceID: "21fc5131-83dd-48ed-be81-94a8419dcbdd", // The ID of your service instance.
         onLoad: function (instance) { instance.render(); }
     };
     setTimeout(function () {
         const t = document.createElement('script');
         t.src = "https://web-chat.global.assistant.watson.appdomain.cloud/loadWatsonAssistantChat.js";
         document.head.appendChild(t);
     });
 </script>


 </asp:Content>