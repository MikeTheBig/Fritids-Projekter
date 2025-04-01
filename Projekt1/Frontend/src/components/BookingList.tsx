import BookingItem from "./BookingItem";

interface Booking {
  bookingId: number;
  customerName: string;
  startDate: string;
}

interface BookingListProps {
  bookings: Booking[];
}

function BookingList({ bookings }: BookingListProps) {
  return (
    <ul className="space-y-2">
      {bookings.map((booking) => (
        <BookingItem key={booking.bookingId} booking={booking} />
      ))}
    </ul>
  );
}

export default BookingList;