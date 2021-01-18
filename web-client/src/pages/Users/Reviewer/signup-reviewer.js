import React from "react";
import "../../../App.css";
import SignInUpInfo from "../../../components/Account/SignInUpInfo";
import SignUpForm from "../../../components/Account/SignUpForm";
import axios from "axios";
import { URL, URL_API } from "../../../Constants";

export default function SignUpReviewer() {
  const signUpReviewerInfo = {
    content:
      "As Reviewer you can see and review other works. If you want to join us and rate scientific works... Sign up ",
    signUpAsOtherLink: "/participant/sign-up",
  };

  const signInReviewer = {
    heading: "Sign in",
    content: "If you have already an account, sign in here",
    btn: "Sign in",
    signInLink: "/reviewer/login",
  };

  const Register = (data) => {
    axios.post(`${URL_API}/Reviewer/Register`, data).then((response) => {
      // OK
      if (response.status === 200) {
        window.location.href = URL;
      }
      // User conflict/user already exists in db
      else if (response.status === 409) {
        // show error or smth
      }
    });
  };

  return (
    <div>
      <h1>Sign up as Reviewer</h1>
      <SignInUpInfo
        content={signUpReviewerInfo.content}
        signUpAsOtherLink={signUpReviewerInfo.signUpAsOtherLink}
      />
      <div>
        <SignUpForm
          GetFormData={Register}
          heading={signInReviewer.heading}
          content={signInReviewer.content}
          btn={signInReviewer.btn}
          signInLink={signInReviewer.signInLink}
        />
      </div>
    </div>
  );
}