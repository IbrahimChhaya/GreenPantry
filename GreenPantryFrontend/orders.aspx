<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="GreenPantryFrontend.orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <!-- Breadcrumb Section Begin -->
    <section class="breadcrumb-section set-bg" data-setbg="img/breadcrumb.jpg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="breadcrumb__text">
                        <h2>Orders</h2>
                        <div class="breadcrumb__option">
                            <a href="./home.aspx">Home</a>
                            <span>Orders</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb Section End -->

    <section class="checkout spad">
        <div class="container">
            <div class="checkout__form" runat="server">
<%--                <form action="#" runat="server">--%>
                    <div class="row">
                        <div class="col-lg-8 col-md-6">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="checkout__input">
                                       
                                    </div>
                                </div>
                            </div>
                            <div>
                                <table class="table orderTable">
                                        <tr>
                                            <th>#</th>
                                            <th>Date</th>
                                            <th>Total</th>
                                            <th>Status</th>
                                            <th></th>
                                        </tr>
                                    <tbody runat="server" id="order">
               
                                        <tr>
                                        <td>
                                            <a href="/invoice.aspx?InvoiceID=1">1</a>
                                        </td>
                                        <td>
                                            2020/09/02
                                        </td>
                                        <td>R428.00</td>
                                        <td>Processing</td>
                                        <td></td>
                                            <td><a class="site-btn" href="/invoice.aspx?InvoiceID=1">View order</a> </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="checkout__order">
                                <h4>Your Account</h4>
                                <div class="checkout__order__products"><a href="account.aspx">Account Details</a></div>
                                <div class="checkout__order__products"><a href="orders.aspx">Orders</a></div>                
                                <div class="checkout__order__products"><a href="shoppinglist.aspx">My Shopping List</a></div>
                                <div class="checkout__order__products"><a href="addressbook.aspx">Address Book</a></div>
                                <div class="checkout__order__products"><a href="home.aspx" id="logout" runat="server" onserverclick="logout_Click">Logout</a></div>
                            </div>
                        </div>
                    </div>
<%--                </form>--%>
            </div>
        </div>
    </section>
    <!-- Checkout Section End -->
</asp:Content>