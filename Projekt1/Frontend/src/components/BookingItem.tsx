interface Booking {
  bookingId: number;
  customerName: string;
  customerEmail: string;
  startDate: string;
  endDate: string;
  showId: number;
}


function BookingItem({ booking }: { booking: Booking }) {
  return (
    <li className="border p-4 rounded">
      <p><strong>Booking ID:</strong> {booking.bookingId}</p>
      <p><strong>Customer Name:</strong> {booking.customerName}</p>
      <p><strong>Email:</strong> {booking.customerEmail}</p>
      <p><strong>Start Date:</strong> {new Date(booking.startDate).toLocaleString()}</p>
      <p><strong>End Date:</strong> {new Date(booking.endDate).toLocaleString()}</p>
      <p><strong>Show ID:</strong> {booking.showId}</p>
    </li>
  );
}

export default BookingItem;