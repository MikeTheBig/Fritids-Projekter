import { useQuery } from "@tanstack/react-query";
import axios from "axios";

interface Booking {
	bookingId: number;
	customerName: string;
	customerEmail: string;
	startDate: string;
	endDate: string;
	showId: number;
}

function BookingList() {
	const token = localStorage.getItem("token");

	const {
		data: bookings,
		isLoading,
		error,
	} = useQuery<Booking[]>({
		queryKey: ["userBookings"],
		queryFn: async () => {
			const response = await axios.get(
				"http://localhost:5210/api/Booking/user",
				{
					headers: {
						Authorization: `Bearer ${token}`,
					},
				}
			);
			return response.data;
		},
	});

	if (isLoading) return <p className="text-blue-500">Loading bookings...</p>;
	if (error instanceof Error)
		return <p className="text-red-500">Error: {error.message}</p>;
	if (!bookings || bookings.length === 0) return <p>No bookings found.</p>;

	return (
		<div className="bg-white shadow-md rounded-lg p-6 max-w-4xl mx-auto mt-8">
			<h2 className="text-xl font-bold text-gray-700 mb-4">Bookings</h2>
			<ul className="space-y-4">
				{bookings?.map((booking) => (
					<li key={booking.bookingId} className="border p-4 rounded shadow-sm">
						<p>
							<strong>Customer Name:</strong> {booking.customerName}
						</p>
						<p>
							<strong>Email:</strong> {booking.customerEmail}
						</p>
						<p>
							<strong>Start Date:</strong>{" "}
							{new Date(booking.startDate).toLocaleString()}
						</p>
						<p>
							<strong>End Date:</strong>{" "}
							{new Date(booking.endDate).toLocaleString()}
						</p>
						<p>
							<strong>Show ID:</strong> {booking.showId}
						</p>
					</li>
				))}
			</ul>
		</div>
	);
}

export default BookingList;
