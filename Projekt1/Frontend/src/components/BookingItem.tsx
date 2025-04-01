interface Booking {
  bookingId: number;
  customerName: string;
  startDate: string;
}

interface BookingItemProps {
  booking: Booking;
}

function BookingItem({ booking }: BookingItemProps) {
  return (
    <li className="p-4 border rounded shadow hover:bg-gray-100">
      <strong>{booking.customerName}</strong> -{" "}
      {new Date(booking.startDate).toLocaleString()}
    </li>
  );
}

export default BookingItem;