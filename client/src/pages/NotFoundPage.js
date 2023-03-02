import { Link } from "react-router-dom";
import styles from "./NotFoundPage.module.css";

const NotFoundPage = () => {
  return (
    <div className={styles["page-root"]}>
      <h1>Oops! You seem to be lost.</h1>
      <p>
        Click <Link to="/">here</Link>, to return to the home page.
      </p>
    </div>
  );
};
export default NotFoundPage;
