<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageA.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MtLoanExt.PageHome.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <style>
        canvas {
            max-width: 100%;
            height: auto;
        }
    </style>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <div id="progressBackground">
                <div id="spinner"></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <!-- Header Content -->
            <section class="content-header d-none">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-sm-6">
                            <h3>
                                <asp:Label ID="lblTitle" runat="server" Text="Welcome to the Building Management System"></asp:Label></h3>
                        </div>
                    </div>
                </div>
            </section>

            <!-- Dashboard Content -->
            <div class="content mt-3">
                <div class="container-fluid">

                    <!-- Row 1: 4 Cards -->
                    <div class="row">
                        <div class="col-lg-3 col-md-6">
                            <div class="card">
                                <div class="card-body">
                                    <i class="fas fa-chart-bar fa-2x text-primary"></i>
                                    <h5 class="card-title">Card 1</h5>
                                    <p class="card-text">Details for Card 1</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <div class="card">
                                <div class="card-body">
                                    <i class="fas fa-chart-bar fa-2x text-primary"></i>
                                    <h5 class="card-title">Card 2</h5>
                                    <p class="card-text">Details for Card 2</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <div class="card">
                                <div class="card-body">
                                    <i class="fas fa-chart-bar fa-2x text-primary"></i>
                                    <h5 class="card-title">Card 3</h5>
                                    <p class="card-text">Details for Card 3</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <div class="card">
                                <div class="card-body">
                                    <i class="fas fa-chart-bar fa-2x text-primary"></i>
                                    <h5 class="card-title">Card 4</h5>
                                    <p class="card-text">Details for Card 4</p>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Row 2: 2 Columns with 2 Cards Each -->
                    <div class="row">
                        <div class="col-lg-6 col-md-12 mb-3">
                            <!-- First Column -->
                            <div class="card mb-3" style="height: 10rem;">
                                <div class="card-body">
                                    <h5 class="card-title">Card 5</h5>
                                    <p class="card-text">Details for Card 5</p>
                                </div>
                            </div>
                            <div class="card" style="height: 20rem;">
                                <div class="card-body">
                                    <h5 class="card-title">Card 6</h5>
                                    <p class="card-text">Details for Card 6</p>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 col-md-12 mb-3">
                            <!-- Second Column -->
                            <div class="card mb-3" style="height: 25rem;">
                                <div class="card-body">
                                    <h5 class="card-title">Card 7</h5>
                                    <p class="card-text">Details for Card 7</p>
                                    <div>
                                        <canvas id="myChart" width="200" height="100"></canvas>
                                    </div>
                                </div>
                            </div>
                            <div class="card" style="height: 10rem;">
                                <div class="card-body">
                                    <h5 class="card-title">Card 8</h5>
                                    <p class="card-text">Details for Card 8</p>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphJavaScript" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            const ctx = document.getElementById('myChart').getContext('2d');
            const myChart = new Chart(ctx, {
                type: 'bar', // ประเภทของกราฟ (เช่น 'line', 'bar', 'pie')
                data: {
                    labels: ['January', 'February', 'March', 'April'], // ชื่อแต่ละแกน X
                    datasets: [{
                        label: 'Dataset 1',
                        data: [12, 19, 3, 5], // ข้อมูลที่จะแสดง
                        backgroundColor: [
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 99, 132, 0.2)'
                        ],
                        borderColor: [
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)',
                            'rgba(255, 99, 132, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        });

        function updateChart(data) {
            myChart.data.datasets[0].data = data;
            myChart.update();
        }
    </script>
</asp:Content>
