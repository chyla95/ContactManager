import { Outlet } from "react-router";
import Header from "../components/Header/Header";
import { getUser } from "../services/user";
import store from "../store/store";
import { userActions } from "../store/user-slice";
import styles from "./RootLayout.module.css";

const RootLayout = (props) => {
  return (
    <>
      <Header />
      <main className={styles["page-root"]}>
        <Outlet />
      </main>
    </>
  );
};

export default RootLayout;

export const rootLoader = async () => {
  const { auth } = store.getState();
  if (!auth.token) return null;

  const user = await getUser(auth.token);
  store.dispatch(userActions.update(user));

  return { user };
};
