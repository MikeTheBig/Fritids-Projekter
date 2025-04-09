import { useEffect, useState } from "react";
import { fetchBookings } from "./api";
import BookingList from "./components/BookingList";
import BookingForm from "./components/BookingForm";
import {
	BrowserRouter as Router,
	Routes,
	Route,
	Navigate,
} from "react-router-dom";
import Login from "./components/Login";
import ProtectedRoute from "./components/ProtectedRoute";
import Homepage from "./components/Homepage";

function App() {
	const [bookings, setBookings] = useState<any[]>([]);
	const [error, setError] = useState<string | null>(null);

	useEffect(() => {
		async function loadBookings() {
			try {
				const data = await fetchBookings();
				setBookings(data);
			} catch (err) {
				setError((err as Error).message);
			}
		}
		loadBookings();
	}, []);

	return (
		<Router>
			<Routes>
				{/* Set Homepage as the front page */}
				<Route path="/" element={<Homepage />} />
				<Route path="/login" element={<Login />} />
				<Route
					path="/bookings"
					element={
						<ProtectedRoute>
							<div className="p-4">
								<h1 className="text-2xl font-bold mb-4">Bookings</h1>
								{error && <p className="text-red-500">{error}</p>}
								<BookingForm />
								<BookingList bookings={bookings} />
							</div>
						</ProtectedRoute>
					}
				/>
			</Routes>
		</Router>
	);
}

export default App;
