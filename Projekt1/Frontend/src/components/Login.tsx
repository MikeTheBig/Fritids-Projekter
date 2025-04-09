import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

function Login() {
	const [username, setUsername] = useState("");
	const [password, setPassword] = useState("");
	const [error, setError] = useState<string | null>(null);
	const navigate = useNavigate();

	const handleSubmit = async (e: React.FormEvent) => {
		e.preventDefault();
		try {
			const response = await axios.post(
				"http://localhost:5210/api/Auth/login",
				{
					username,
					password,
				}
			);
			const token = response.data.token;
			localStorage.setItem("token", token); // Store the token in local storage
			navigate("/bookings"); // Redirect to bookings page
		} catch (err: any) {
			setError(err.response?.data?.message || "Invalid username or password");
		}
	};

	return (
		<form
			onSubmit={handleSubmit}
			className="space-y-4 max-w-md mx-auto p-4 bg-white shadow-md rounded"
		>
			<h2 className="text-xl font-bold text-gray-700">Login</h2>
			{error && <p className="text-red-500">{error}</p>}
			<div>
				<label className="block font-bold text-gray-600">Username</label>
				<input
					type="text"
					value={username}
					onChange={(e) => setUsername(e.target.value)}
					className="border p-2 rounded w-full"
					placeholder="Enter your username"
				/>
			</div>
			<div>
				<label className="block font-bold text-gray-600">Password</label>
				<input
					type="password"
					value={password}
					onChange={(e) => setPassword(e.target.value)}
					className="border p-2 rounded w-full"
					placeholder="Enter your password"
				/>
			</div>
			<button
				type="submit"
				className="bg-blue-500 text-white p-2 rounded w-full hover:bg-blue-600"
			>
				Login
			</button>
		</form>
	);
}

export default Login;
