import { useState } from "react";
import { createBooking } from "../api";

function BookingForm() {
  const [customerName, setCustomerName] = useState("");
  const [customerEmail, setCustomerEmail] = useState("");
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [showId, setShowId] = useState<number | null>(null);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      if (!showId) {
        setError("Please select a show.");
        return;
      }

      const newBooking = {
        customerName,
        customerEmail,
        startDate,
        endDate,
        showId,
      };
      console.log("Sending booking data:", newBooking); // Debugging
      await createBooking(newBooking);
      alert("Booking created successfully!");
    } catch (err) {
      console.error("Error creating booking:", err); // Debugging
      setError((err as Error).message);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-4">
      {error && <p className="text-red-500">{error}</p>}
      <div>
        <label className="block font-bold">Customer Name</label>
        <input
          type="text"
          value={customerName}
          onChange={(e) => setCustomerName(e.target.value)}
          className="border p-2 rounded w-full"
        />
      </div>
      <div>
        <label className="block font-bold">Customer Email</label>
        <input
          type="email"
          value={customerEmail}
          onChange={(e) => setCustomerEmail(e.target.value)}
          className="border p-2 rounded w-full"
        />
      </div>
      <div>
        <label className="block font-bold">Start Date</label>
        <input
          type="datetime-local"
          value={startDate}
          onChange={(e) => setStartDate(e.target.value)}
          className="border p-2 rounded w-full"
        />
      </div>
      <div>
        <label className="block font-bold">End Date</label>
        <input
          type="datetime-local"
          value={endDate}
          onChange={(e) => setEndDate(e.target.value)}
          className="border p-2 rounded w-full"
        />
      </div>
      <div>
        <label className="block font-bold">Show</label>
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
      <button type="submit" className="bg-blue-500 text-white p-2 rounded">
        Create Booking
      </button>
    </form>
  );
}

export default BookingForm;