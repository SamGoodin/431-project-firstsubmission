<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CourseProject.Default" %>
<!DOCTYPE html>
<!--
	Transitive by TEMPLATED
	templated.co @templatedco
	Released for free under the Creative Commons Attribution 3.0 license (templated.co/license)
-->


<!-- TO MY GROUP :)
	files that i've created: 
	create-admin.aspx
	manager-register.aspx
	register.aspx
	login.aspx
	Sample.aspx
	Default.aspx

	Default is like an index.html file, main page. Sample.aspx is a file you can use for creating new pages, copy contents, save as new aspx file, dont modify original.
	the style file is main.css, create your own classes at the end of the file, but that shouldnt be necessary. Adhere to the form practices from the register file.
	Use proper divs for mobile compatibility. 

-->

<html>
	<head>
		<title>K-12 STEM Outreach</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<link rel="stylesheet" href="assets/css/main.css" />
	</head>
	<body>

		<!-- Header -->
			<header id="header" class="alt">
				<div class="logo"><a href="Default.aspx">K-12 STEM Outreach</a></div>
				<a href="#menu" class="toggle"><span>Menu</span></a>
			</header>

		<!-- Nav -->
			<nav id="menu">
				<ul class="links">
					<li><a href="login.aspx">Login</a></li>
					<li><a href="register.aspx">Register</a></li>					
				</ul>

			</nav>
		
		<!-- Banner -->
		<!--
			To use a video as your background, set data-video to the name of your video without
			its extension (eg. images/banner). Your video must be available in both .mp4 and .webm
			formats to work correctly.
		-->

			<section id="banner">
				<div class="inner">
					<h1>K-12 STEM Outreach</h1>
					<p>Welcome to our STEM Education Outreach Programs and Events Website!</p>
					<a href="login.aspx" class="button">Login</a>
					<a href="register.aspx" class="button">Register</a>					
				</div>

			</section>
		

		<!-- Footer -->
			<footer id="footer" class="wrapper">
				<div class="inner">
					<div class="copyright">
						&copy; Untitled Design: <a href="https://templated.co/">TEMPLATED</a>
					</div>
				 </div>
			</footer>

		<!-- Scripts -->
			<script src="assets/js/jquery.min.js"></script>
			<script src="assets/js/jquery.scrolly.min.js"></script>
			<script src="assets/js/jquery.scrollex.min.js"></script>
			<script src="assets/js/skel.min.js"></script>
			<script src="assets/js/util.js"></script>
			<script src="assets/js/main.js"></script>

	</body>
</html>