import { createBrowserRouter } from "react-router-dom";
import RootLayout, { rootLoader } from "./layouts/RootLayout";
import HomePage, { homePageLoader } from "./pages/HomePage";
// import PostPage, { postLoader } from "./pages/PostPage";
// import PostsPage, { postsLoader } from "./pages/PostsPage";

const routes = [
  {
    path: "/",
    element: <RootLayout />,
    loader: rootLoader,
    children: [
      { path: "/", element: <HomePage />, loader: homePageLoader },
      // { path: "/post/:postId", element: <PostPage />, loader: postLoader },
    ],
  },
];

const router = createBrowserRouter(routes);

export default router;
