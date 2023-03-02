import { MdLock } from "react-icons/md";
import { useSelector } from "react-redux";
import { useLoaderData, useNavigate } from "react-router-dom";
import Contacts from "../components/contacts/Contacts";
import { getPrivateContacts, getPublicContacts } from "../services/contact";
import store from "../store/store";
import styles from "./PrivateContactsPage.module.css";

const PrivateContactsPage = (props) => {
  const loaderData = useLoaderData();
  const { user } = useSelector((state) => state.user);
  const navigate = useNavigate();

  const accentColor = getComputedStyle(document.body).getPropertyValue(
    "--color-accent-light"
  );

  let contactList = <h3>You have no contacts yet</h3>;
  if (!user) contactList = <h3>You are not authorized</h3>;
  if (loaderData && loaderData.contacts.length > 0) {
    contactList = <Contacts contacts={loaderData.contacts} areClickable />;
  }

  const newContactHandler = () => {
    navigate("/private-contacts/new");
  };

  return (
    <div className={styles["page-root"]}>
      <h1 className={styles["page-title"]}>
        <MdLock color={accentColor} /> Private contacts
      </h1>
      {contactList}
      <button
        className={styles["new-contact-button"]}
        onClick={newContactHandler}
      >
        New Contact
      </button>
    </div>
  );
};
export default PrivateContactsPage;

export const privateContactsPageLoader = async () => {
  const { auth } = store.getState();
  if (!auth.token) return null;

  const contacts = await getPrivateContacts(auth.token);
  return { contacts };
};
