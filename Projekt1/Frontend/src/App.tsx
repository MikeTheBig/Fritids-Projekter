import { useEffect, useState } from "react";
import { fetchBookings } from "./api";
import BookingList from "./components/BookingList";
import BookingForm from "./components/BookingForm";

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
    <div className="p-4">
      <h1 className="text-2xl font-bold mb-4">Bookings</h1>
      {error && <p className="text-red-500">{error}</p>}
      <BookingForm />
      <BookingList bookings={bookings} />
    </div>
  );
}

export default App;