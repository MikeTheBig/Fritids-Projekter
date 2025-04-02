import { useState } from "react";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import axiosInstance from "../axiosInstance";

function BookingForm() {
	const [customerName, setCustomerName] = useState("");
	const [customerEmail, setCustomerEmail] = useState("");
	const [startDate, setStartDate] = useState("");
	const [endDate, setEndDate] = useState("");
	const [showId, setShowId] = useState<number | null>(null);
	const [userId, setUserId] = useState<number | null>(null);
	const [error, setError] = useState<string | null>(null);
	const queryClient = useQueryClient();

	const mutation = useMutation({
		mutationFn: async (newBooking: {
			customerName: string;
			customerEmail: string;
			startDate: string;
			endDate: string;
			showId: number;
			userId: number;
		}) => {
			const response = await axiosInstance.post("/Booking", newBooking);
			return response.data;
		},
		onSuccess: () => {
			queryClient.invalidateQueries(["bookings"]);
			alert("Booking created successfully!");
			setCustomerName("");
			setCustomerEmail("");
			setStartDate("");
			setEndDate("");
			setShowId(null);
			setUserId(null);
			setError(null);
		},
		onError: (err: any) => {
			if (err.response && err.response.data && err.response.data.errors) {
				const backendErrors = err.response.data.errors;
				const errorMessages = Object.values(backendErrors).flat().join(", ");
				setError(errorMessages);
			} else {
				setError(err.message || "Failed to create booking");
			}
		},
	});

	const handleSubmit = (e: React.FormEvent) => {
		e.preventDefault();
		if (!showId || !userId) {
			setError("Please select a show and provide a user ID.");
			return;
		}

		const newBooking = {
			customerName,
			customerEmail,
			startDate,
			endDate,
			showId,
			userId,
		};

		mutation.mutate(newBooking);
	};

	return (
		<form
			onSubmit={handleSubmit}
			className="space-y-6 bg-white shadow-md rounded-lg p-6 max-w-lg mx-auto"
		>
			<h2 className="text-xl font-bold text-gray-700">Create a Booking</h2>
			{error && <p className="text-red-500">{error}</p>}
			<div>
				<label className="block font-bold text-gray-600">Customer Name</label>
				<input
					type="text"
					value={customerName}
					onChange={(e) => setCustomerName(e.target.value)}
					className="border p-2 rounded w-full"
					placeholder="Enter customer name"
				/>
			</div>
			<div>
				<label className="block font-bold text-gray-600">User ID</label>
				<input
					type="number"
					value={userId || ""}
					onChange={(e) => setUserId(Number(e.target.value))}
					className="border p-2 rounded w-full"
					placeholder="Enter user ID"
				/>
			</div>
			<div>
				<label className="block font-bold text-gray-600">Customer Email</label>
				<input
					type="email"
					value={customerEmail}
					onChange={(e) => setCustomerEmail(e.target.value)}
					className="border p-2 rounded w-full"
					placeholder="Enter customer email"
				/>
			</div>
			<div>
				<label className="block font-bold text-gray-600">Start Date</label>
				<input
					type="datetime-local"
					value={startDate}
					onChange={(e) => setStartDate(e.target.value)}
					className="border p-2 rounded w-full"
				/>
			</div>
			<div>
				<label className="block font-bold text-gray-600">End Date</label>
				<input
					type="datetime-local"
					value={endDate}
					onChange={(e) => setEndDate(e.target.value)}
					className="border p-2 rounded w-full"
				/>
			</div>
			<div>
				<label className="block font-bold text-gray-600">Show</label>
				<select
					value={showId || ""}
					onChange={(e) => setShowId(Number(e.target.value))}
					className="border p-2 rounded w-full"
				>
					<option value="">Select a show</option>
					<option value="1">Show 1</option>
					<option value="2">Show 2</option>
				</select>
			</div>
			<button
				type="submit"
				className="bg-blue-500 text-white p-2 rounded w-full hover:bg-blue-600"
			>
				Create Booking
			</button>
		</form>
	);
}

export default BookingForm;
