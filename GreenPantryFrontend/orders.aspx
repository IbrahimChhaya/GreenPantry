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
                <form action="#" runat="server">
                    <div class="row">
                        <div class="col-lg-8 col-md-6">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="checkout__input">
                                       
                                    </div>
                                </div>
                            </div>
        <table>
            <tbody>
                <tr>
                    <th>#</th>
                    <th>Date</th>
                    <th>Total</th>
                    <th>Status</th>
                    <th>View</th>
                </tr>
                <tr>
                <td>
                    <a href="/invoice.aspx?InvoiceID=6">2526056</a>
                </td>
                <td>
                    <span class="long">04 July 2020 at&nbsp;11:24</span>
                    <span class="short">04/07/2020</span>
                </td>
                <td>R238</td>
                <td>Dispatched</td>
                <td>
                    <td><a class="site-btn" href="/invoice.aspx?InvoiceID=6">View order</a> </td>
                </tr>
                <tr>
                <td>
                    <a href="/invoice.aspx?InvoiceID=6">2505630</a>
                </td>
                <td>
                    <span class="long">27 June 2020 at&nbsp;11:53</span>
                    <span class="short">27/06/2020</span>
                </td>
                <td>R4,208</td>
                <td>Dispatched</td>
                <td>
                    <td><a class="site-btn" href="/invoice.aspx?InvoiceID=6">View order</a> </td>
                </tr>
                <tr>
                <td>
                    <a href="/invoice.aspx?InvoiceID=6">1539399</a>
                </td>
                <td>
                    <span class="long">10 March 2019 at&nbsp;10:43</span>
                    <span class="short">10/03/2019</span>
                </td>
                <td>R254</td>
                <td>Dispatched</td>
                <td>
                    <td><a class="site-btn" href="/invoice.aspx?InvoiceID=6">View order</a> </td>
                </tr>
                <tr>
                    <td>
                        <a href="/invoice.aspx?InvoiceID=6">1373073</a>
                    </td>
                    <td>
                        <span class="long">26 November 2018 at&nbsp;08:54</span>
                        <span class="short">26/11/2018</span>
                    </td>
                    <td>R658</td>
                    <td>Dispatched</td>
                    <td><a class="site-btn" href="/invoice.aspx?InvoiceID=6">View order</a> </td>
                </tr>
            </tbody>
        </table>
                            </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="checkout__order">
                                <h4>Your Account</h4>
                                <div class="checkout__order__products">Products <span>Total</span></div>
                                <ul>
                                    <li>View All Orders <span>$75.99</span></li>
                                    <li>Account Details <span>$151.99</span></li>
                                    <li>WAP <span>$53.99</span></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </section>
    <!-- Checkout Section End -->
    </asp:Content>