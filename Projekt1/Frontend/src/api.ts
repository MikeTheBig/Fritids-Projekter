import API_BASE_URL from "./config";

export async function fetchShows() {
  const response = await fetch(`${API_BASE_URL}/Show`);
  if (!response.ok) {
    throw new Error("Failed to fetch shows");
  }
  return response.json();
}

export async function fetchBookings() {
  const token = localStorage.getItem("jwtToken"); // Retrieve the token from local storage
  if (!token) {
    throw new Error("User is not authenticated");
  }

  const response = await fetch("http://localhost:5210/api/Booking/user", {
    method: "GET",
    headers: {
      "Authorization": `Bearer ${token}`, // Include the token in the Authorization header
      "Content-Type": "application/json",
    },
  });

  if (!response.ok) {
    throw new Error(`Failed to fetch bookings: ${response.statusText}`);
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