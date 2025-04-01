import API_BASE_URL from "./config";

export async function fetchShows() {
  const response = await fetch(`${API_BASE_URL}/Show`);
  if (!response.ok) {
    throw new Error("Failed to fetch shows");
  }
  return response.json();
}

export async function fetchBookings() {
  const response = await fetch(`${API_BASE_URL}/Booking`);
  if (!response.ok) {
    throw new Error("Failed to fetch bookings");
  }
  return response.json();
}

export async function createBooking(booking: {
  customerName: string;
  customerEmail: string;
  startDate: string;
  endDate: string;
  showId: number | null;
}) {
  const response = await fetch(`${API_BASE_URL}/Booking`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(booking),
  });

  if (!response.ok) {
    throw new Error("Failed to create booking");
  }

  return response.json();
}