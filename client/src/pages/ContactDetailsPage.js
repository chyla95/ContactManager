import { useLoaderData } from "react-router-dom";
import ContactForm from "../components/contacts/ContactForm";
import { getCategories } from "../services/category";
import { getPrivateContact } from "../services/contact";
import store from "../store/store";
import styles from "./ContactDetailsPage.module.css";

const ContactDetailsPage = (props) => {
  const { contact, categories } = useLoaderData();

  return (
    <div className={styles["page-root"]}>
      <ContactForm mode="EDIT" contact={contact} categories={categories} />
    </div>
  );
};
export default ContactDetailsPage;

export const contactDetailsPageLoader = async ({ params }) => {
  const { contactId } = params;

  const { auth } = store.getState();
  if (!auth.token) return null;

  const contact = await getPrivateContact(contactId, auth.token);
  const categories = await getCategories(auth.token);
  return { contact, categories };
};
