import { Navigate } from "react-router-dom";

function ProtectedRoute({ children }: { children: JSX.Element }) {
	const token = localStorage.getItem("token");
	if (!token) {
		return <Navigate to="/login" />;
	}
	return children;
}

export default ProtectedRoute;
