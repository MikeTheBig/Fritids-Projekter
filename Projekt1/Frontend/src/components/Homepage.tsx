import React from "react";

const Homepage: React.FC = () => {
	return (
		<div style={{ textAlign: "center", padding: "20px" }}>
			<h1>Welcome to the Booking System</h1>
			<p>Manage your bookings and explore available shows.</p>
			<div style={{ marginTop: "20px" }}>
				<button
					style={{
						padding: "10px 20px",
						margin: "10px",
						backgroundColor: "#007BFF",
						color: "white",
						border: "none",
						borderRadius: "5px",
						cursor: "pointer",
					}}
					onClick={() => (window.location.href = "/login")}
				>
					Login
				</button>
				<button
					style={{
						padding: "10px 20px",
						margin: "10px",
						backgroundColor: "#28A745",
						color: "white",
						border: "none",
						borderRadius: "5px",
						cursor: "pointer",
					}}
					onClick={() => (window.location.href = "/register")}
				>
					Register
				</button>
			</div>
		</div>
	);
};

export default Homepage;
