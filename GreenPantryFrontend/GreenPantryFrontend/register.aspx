<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="GreenPantryFrontend.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Hero Section Begin -->
    <section class="hero hero-normal">
        <div class="container">
            <div class="row">
                <div class="col-lg-3">
                    <div class="hero__categories">
                        <div class="hero__categories__all">
                            <i class="fa fa-bars"></i>
                            <span>All departments</span>
                        </div>
                        <ul>
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
                                <h5>+27 11 616 8269</h5>
                                <span>support 24/7 time</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Hero Section End -->

    <!-- Breadcrumb Section Begin 
<style>
    #grad1 {
        height: 200px;
        background-color: #0FAB2C; /* For browsers that do not support gradients */
        background-image: linear-gradient(to right, #0FAB2C, #1FAF92); /* Standard syntax (must be last) */
        }
</style> -->

    <section class="breadcrumb-section set-bg" data-setbg="img/breadcrumb.jpg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="breadcrumb__text">
                        <h2>Register</h2>
                        <div class="breadcrumb__option">
                            <a href="./home.aspx">Home</a>
                            <span>Register</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb Section End -->

    </br>
    </br>

    <!-- <form action="#" runat="server">
        
                            <div class="center">
        <div class="container">

                <div class="row">                        
                            <input type="text" name="first_name" placeholder="Email"
                                onfocus="this.placeholder = ''" onblur="this.placeholder = 'Email'" required
                                runat="server" id="Email">
                </div>
                <div class="row">                        
                            <input type="text" name="last_name" placeholder="Password"
                                onfocus="this.placeholder = ''" onblur="this.placeholder = 'Password'" required
                                runat="server" id="Password">
                </div>    
                        <button type="submit" class="site-btn">LOGIN</button>                            
                            <a href="register.aspx" class="genric-btn info-border">Register</a>
                        
                    <div class="mt-10">
                            <asp:Label ID="error" runat="server" Text="Incorrect Password or Username" visible="false" ></asp:Label>
                    </div>
                                </div>
           </div>                           <input type="text" placeholder="Your Email">

    </form>

    <div class="contact-form spad">
        <div class="container">
            <form action="#">
                <div class="row">
                    <div class="col-lg-12 text-center">
                    <div class="col-lg-6 col-md-6">
                        <input type="text" placeholder="Your name">
                     </div>
                        <button type="submit" class="site-btn">LOGIN</button>
                    </div>
                </div>
            </form>
        </div>
    </div>-->


    <style>
        .testText {
            margin:0 auto;
            width:125px;
            padding-bottom:25px;
        }
    </style>
       <div class="testText">
        <input type="text" placeholder="First Name" runat="server" ID="firstname" />
        </br>
        </br>
        <input type="text" placeholder="Last Name" runat="server" ID="lastname" />
        </br>
        </br>
        <input type="email" placeholder="Email" runat="server" ID="userEmail" />
        </br>
        </br>
        <input type="password" placeholder="Password" runat="server" ID="userPassword"/>
        </br>
        </br>
        <input type="password" placeholder="Confirm Password" runat="server" ID="cPassword" />
        </br>
        </br>
        <asp:button type="submit" class="site-btn" runat="server" ID="Register" OnClick="Register_Click" Text="REGISTER"></asp:button>
    </div>

</asp:Content>