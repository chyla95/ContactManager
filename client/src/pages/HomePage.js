import { MdPublic } from "react-icons/md";
import { useLoaderData } from "react-router-dom";
import Contacts from "../components/contacts/Contacts";
import { getPublicContacts } from "../services/contact";
import styles from "./HomePage.module.css";

const HomePage = (props) => {
  const { contacts } = useLoaderData();
  const accentColor = getComputedStyle(document.body).getPropertyValue(
    "--color-accent-light"
  );

  return (
    <div className={styles["page-root"]}>
      <h1 className={styles["page-title"]}>
        <MdPublic color={accentColor} /> Public contacts
      </h1>
      <Contacts contacts={contacts} />
    </div>
  );
};
export default HomePage;

export const homePageLoader = async () => {
  const contacts = await getPublicContacts();
  return { contacts };
};
