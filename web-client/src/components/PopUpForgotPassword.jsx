import React, { useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import * as yup from "yup";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import Dialog from "@material-ui/core/Dialog";
import Snackbar from "@material-ui/core/Snackbar";
import MuiAlert from "@material-ui/lab/Alert";

const styles = makeStyles({
  main: {
    display: "inline-block",
  },
  content: {
    padding: "30px 100px",
  },
  form: {
    display: "flex",
    flexDirection: "column",
    float: "left",
    textAlign: "left",
    maxWidth: "400px",
    margin: "16px",
  },
  textField: {
    marginBottom: "32px",
    width: "300px",
  },
  send: {
    width: "100px",
    textTransform: "none",
    float: "right",
    marginLeft: "auto",
    display: "block",
  },
  textButton: {
    textTransform: "none",
  },
  message: {
    textAlign: "center",
    marginTop: "30px",
    marginBottom: "30px",
  },
});

function Alert(props) {
  return <MuiAlert elevation={6} {...props} />;
}

const duration = 4000;

export default function PopUpForgotPassword(props) {
  const [email, setEmail] = useState("");

  const schema = yup.object().shape({
    email: yup
      .string()
      .email("Email should have correct format")
      .required("Required field"),
  });

  const [open, SetOpen] = React.useState(false);
  const [openAlertSuccess, SetOpenAlertSuccess] = React.useState(false);
  const [openAlertError, SetOpenAlertError] = React.useState(false);

  const { register, errors } = useForm({
    mode: "onBlur",
    resolver: yupResolver(schema),
  });

  const handleChange = (event) => {
    setEmail(event.target.value);
  };

  const handleClickOpen = () => {
    SetOpen(true);
    setEmail("");
  };

  const handleClose = () => {
    SetOpen(false);
  };

  // Show alert: successfully or unsuccessfully
  const ShowAlert = (bool) => {
    if(bool) SetOpenAlertSuccess(true);
    else SetOpenAlertError(true);
  };

  // Close alert
  const CloseAlert = (event, reason) => {
    if (reason === "clickaway") return;

    SetOpenAlertSuccess(false);
    SetOpenAlertError(false);
  };

  const style = styles();

  let isSuccessfully = email !== "";

  const submit = () => {
    if (isSuccessfully) {
      props.SetEmail(email);
      alert(email);
    }
    ShowAlert(isSuccessfully);
  };

  return (
    <div className={style.main}>
      {/* Forgot password */}
      <Button
        className={style.textButton}
        color="primary"
        onClick={handleClickOpen}
      >
        Forgot password?
      </Button>

      <Dialog open={open} onClose={handleClose}>
        <span className={style.message}>You will receive link...</span>
        <div className={style.content}>
          <div className={style.form}>
            <TextField
              className={style.textField}
              inputRef={register}
              required
              id="forgot-email-signin"
              name="email"
              label="Login/Email"
              type="email"
              value={email}
              autoComplete="email"
              onChange={handleChange}
              InputLabelProps={{
                shrink: true,
              }}
              variant="outlined"
              error={!!errors.email}
              helperText={errors?.email?.message}
            />
            {/* Button Send */}
            <Button
              className={style.send}
              color="primary"
              variant="contained"
              onClick={submit}
            >
              Send
            </Button>
          </div>
        </div>
      </Dialog>
      {/* Successfully send email */}
      <Snackbar
        open={openAlertSuccess}
        autoHideDuration={duration}
        onClose={CloseAlert}
      >
        <Alert onClose={CloseAlert} severity={"success"}>
          {"Link has been sent"}
        </Alert>
      </Snackbar>
      {/* Unsuccessfully send email */}
      <Snackbar
        open={openAlertError}
        autoHideDuration={duration}
        onClose={CloseAlert}
      >
        <Alert onClose={CloseAlert} severity={"error"}>
          {"Link has not been sent"}
        </Alert>
      </Snackbar>
    </div>
  );
}
