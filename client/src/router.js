import { createBrowserRouter } from "react-router-dom";
import RootLayout, { rootLoader } from "./layouts/RootLayout";
import ContactDetailsPage, {
  contactDetailsPageLoader,
} from "./pages/ContactDetailsPage";
import HomePage, { homePageLoader } from "./pages/HomePage";
import NewContactPage, { newContactPageLoader } from "./pages/NewContactPage";
import NotFoundPage from "./pages/NotFoundPage";
import PrivateContactsPage, {
  privateContactsPageLoader,
} from "./pages/PrivateContactsPage";

const routes = [
  {
    path: "/",
    element: <RootLayout />,
    loader: rootLoader,
    children: [
      {
        path: "/",
        element: <HomePage />,
        loader: homePageLoader,
      },
      {
        path: "/private-contacts",
        element: <PrivateContactsPage />,
        loader: privateContactsPageLoader,
      },
      {
        path: "/private-contacts/new",
        element: <NewContactPage />,
        loader: newContactPageLoader,
      },
      {
        path: "/private-contacts/:contactId",
        element: <ContactDetailsPage />,
        loader: contactDetailsPageLoader,
      },
      {
        path: "*",
        element: <NotFoundPage />,
      },
    ],
  },
];

const router = createBrowserRouter(routes);

export default router;
