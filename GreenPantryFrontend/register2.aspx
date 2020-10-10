<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="register2.aspx.cs" Inherits="GreenPantryFrontend.register2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<br />
    <br />
	<br />
    <!-- Login form -->
    
	<div class="bodylogin loginPage" id="test">
		<div class="containerlogin right-panel-active" id="container">
			<div class="form-container sign-up-container">
				<div class="loginForm">
					<h1 class="h1login">Create Account</h1>
					<br />

					<input class="login" type="text" placeholder="Name" runat="server" ID="name"  required/>
					<input class="login" type="text" placeholder="Last name" runat="server" ID="surname" required/>
					<input class="login" type="email" placeholder="Email" runat="server" ID="RegEmail" required/>
					<input class="login" type="password" placeholder="Password (8 characters min)"  runat="server" ID="Password1"   minlength="8" title="Passwords must be at least 8 characters long" data-placement="right" required />
					<%--<input class="login" type="password" placeholder="Password" runat="server" ID="RegPassword"/>--%>
					<%--<input class="login" type="password" placeholder="Password" runat="server" ID="Password1" data-toggle="popover" title="Password Requirement" data-placement="right" data-content="Passwords must be at least 8 characters long" />--%>
				
					<asp:Label ID="error" runat="server" Text="Incorrect Password or Username" visible="false" ></asp:Label>
					<asp:button class="login" runat="server" ID="Register" OnClick="Register_Click" Text="Sign Up"></asp:button>
				</div>
			</div>
			<%--<div class="form-container sign-in-container">
				<form class="login">
					<h1 class="h1login" id="closePopup">Sign in</h1>
					</br>
					<input class="login" type="email" placeholder="Email" runat="server" ID="Email"/>
					<input class="login" type="password" placeholder="Password" runat="server" ID="Password" />
                    <asp:Label ID="error" runat="server" Text="Incorrect Password or Username" visible="false" ></asp:Label>
					<a class="login" href="#">Forgot your password?</a>
                    <asp:button class="login" runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="Sign In" ></asp:button>
				</form>
			</div>--%>
			<div class="overlay-container">
				<div class="overlay">
					<div class="overlay-panel overlay-left">
						<h1 class="h1login">Welcome Back!</h1>
						<p class="plogin">To keep connected with us please login with your personal info</p>
						<%--<form action="/login.aspx">
							<button class="login ghost" id="signIn">Sign In</button>
						</form>--%>
						<a href="login.aspx" class="login ghost">Sign In</a>
						</div>
					<div class="overlay-panel overlay-right">
						<h1 class="h1login">Hello, jimo</h1>
						<p class="plogin">ur dumb</p>
						<button class="login ghost">Sign Up</button>
					</div>
				</div>
			</div>
		</div>
    </div>
    <br />
    <br />
	<br />
</asp:Content>