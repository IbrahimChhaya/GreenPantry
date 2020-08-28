<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GreenPantryFrontend.login2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/logincss.css" type="text/css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    </br>
    </br>
    </br>
    <!-- Login form -->
    <style>
        .loginPage {
            background: #FFFFFF;
        }
    </style>
	<div class="bodylogin loginPage" id="test">
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
						<p class="plogin">To keep connected with us please login with your personal info</p>
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
    </br>
    </br>
    </br>
</asp:Content>