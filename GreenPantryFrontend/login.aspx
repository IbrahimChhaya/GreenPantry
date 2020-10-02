<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GreenPantryFrontend.login2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <!-- Login form -->
    
	<div class="bodylogin loginPage" id="test">
		<div class="containerlogin" id="container">
			<div class="form-container sign-up-container">
				<div class="loginForm">
					<h1 class="h1login">Create Account</h1>
					<br />
					<input class="login" type="text" placeholder="Name" runat="server" ID="name" />
				<input class="login" type="text" placeholder="Last name" runat="server" ID="surname"/>
					<input class="login" type="email" placeholder="Email" runat="server" ID="RegEmail"/>
					<input class="login" type="password" placeholder="Password" runat="server" ID="RegPassword"/>
					<button class="login" runat="server" ID="btnRegister" OnClick="Sign Up">Sign Up</button>
				</div>
			</div>
			<div class="form-container sign-in-container" id="loginDiv" runat="server">
				<form class="login" runat="server" >
					<h1 class="h1login" id="closePopup">Sign in</h1>
					<br />
					<input class="login" type="email" placeholder="Email" runat="server" ID="Email"/>
					<input class="login" type="password" placeholder="Password" runat="server" ID="Password" />
                    <asp:Label ID="error" runat="server" Text="Incorrect Password or Username" visible="false" ></asp:Label>
					<a class="login" href="login.aspx?Reset=true">Forgot your password?</a>
                    <asp:button class="login" runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="Sign In" ></asp:button>
				</form>
			</div>
			<div class="form-container sign-in-container" id="resetDiv" runat="server" visible="false">
				<form class="login" runat="server">
					<h1 class="h1login">Forgot password?</h1>
					<br />
					<span id="resetText" runat="server">We'll email you a link to reset your password</span>
					<input class="login" type="email" placeholder="Email" runat="server" ID="forgotEmail"/>
                    <asp:button class="login" runat="server" ID="btnReset" OnClick="btnReset_Click" Text="Reset Password" ></asp:button>
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
						<h1 class="h1login">Hello there!</h1>
						<p class="plogin">Sign in to start shopping</p>
						<form action="/register2.aspx">
							<button class="login ghost" id="signUp">Sign Up</button>
						</form>
					</div>
				</div>
			</div>
		</div>
    </div>
    <br />
    <br />
    <br />
</asp:Content>