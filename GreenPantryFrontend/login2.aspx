<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login2.aspx.cs" Inherits="GreenPantryFrontend.login2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/logincss.css" type="text/css">
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
                                <input type="text" placeholder="What do yo u need?">
                                <button type="submit" class="site-btn" onclick="document.getElementById('test').style.visibility = 'visible'">SEARCH</button>
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

    <!-- Login form -->
	<div class="bodylogin" id="test">
		<div class="containerlogin" id="container">
			<div class="form-container sign-up-container">
				<form class="login" action="#">
					<h1 class="h1login">Create Account</h1>
					</br>
					<input class="login" type="text" placeholder="Name" />
				<input class="login" type="text" placeholder="Last name" />
					<input class="login" type="email" placeholder="Email" />
					<input class="login" type="password" placeholder="Password" />
					<button class="login">Sign Up</button>
				</form>
			</div>
			<div class="form-container sign-in-container">
				<form class="login" action="#">
					<h1 class="h1login" id="closePopup">Sign in</h1>
					</br>
					<input class="login" type="email" placeholder="Email" />
					<input class="login" type="password" placeholder="Password" />
					<a class="login" href="#">Forgot your password?</a>
					<button class="login">Sign In</button>
				</form>
			</div>
			<div class="overlay-container">
				<div class="overlay">
					<div class="overlay-panel overlay-left">
						<h1 class="h1login">Welcome Back!</h1>
						<p class="login">To keep connected with us please login with your personal info</p>
						<button class="login ghost" id="signIn">Sign In</button>
					</div>
					<div class="overlay-panel overlay-right">
						<h1 class="h1login">Hello, jimo</h1>
						<p class="plogin">ur dumb</p>
						<button class="login ghost" id="signUp">Sign Up</button>
					</div>
				</div>
			</div>
		</div>
    </div>
</asp:Content>