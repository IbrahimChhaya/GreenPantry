<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login2.aspx.cs" Inherits="GreenPantryFrontend.login2" %>
<html>
	<head runat="server">
		<title>hey</title>
	    <link rel="stylesheet" href="/logincss.css" type="text/css">

		</head>

	<body>
    <div class="container" id="container">
	    <div class="form-container sign-up-container">
		    <form action="#">
			    <h1>Create Account</h1>
			    </br>
			    <input type="text" placeholder="Name" />
		    <input type="text" placeholder="Last name" />
			    <input type="email" placeholder="Email" />
			    <input type="password" placeholder="Password" />
			    <button>Sign Up</button>
		    </form>
	    </div>
	    <div class="form-container sign-in-container">
		    <form action="#">
			    <h1>Sign in</h1>
			    </br>
			    <input type="email" placeholder="Email" />
			    <input type="password" placeholder="Password" />
			    <a href="#">Forgot your password?</a>
			    <button>Sign In</button>
		    </form>
	    </div>
	    <div class="overlay-container">
		    <div class="overlay">
			    <div class="overlay-panel overlay-left">
				    <h1>Welcome Back!</h1>
				    <p>To keep connected with us please login with your personal info</p>
				    <button class="ghost" id="signIn">Sign In</button>
			    </div>
			    <div class="overlay-panel overlay-right">
				    <h1>Hello, Zeearak</h1>
				    <p>ur dumb</p>
				    <button class="ghost" id="signUp">Sign Up</button>
			    </div>
		    </div>
	    </div>
    </div>
				    <script src="/loginjs.js"></script>

    </body>
	</html>
