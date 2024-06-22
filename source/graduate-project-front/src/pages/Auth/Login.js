import './Login.css';
import { useState } from 'react';
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';

function Login({ onLogin }) {
  const initialValues = { username: "", password: "" };
  const [formValues, setFormValues] = useState({
    username: localStorage.getItem("rememberMe") === "true" ? localStorage.getItem("username") || "" : "",
    password: localStorage.getItem("rememberMe") === "true" ? localStorage.getItem("password") || "" : "",
  });
  const [formErrors, setFormErrors] = useState({});
  const [rememberMe, setRememberMe] = useState(localStorage.getItem("rememberMe") === "true");

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormValues({ ...formValues, [name]: value });
  };

  const handleRememberMe = () => {
    setRememberMe(!rememberMe);
    if (!rememberMe) {
      localStorage.setItem("username", formValues.username);
      localStorage.setItem("password", formValues.password);
      localStorage.setItem("rememberMe", true);
    } else {
      localStorage.removeItem("username");
      localStorage.removeItem("password");
      localStorage.removeItem("rememberMe");
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const errors = validate(formValues);
    setFormErrors(errors);
    if (Object.keys(errors).length === 0) {
      onLogin(formValues.username, formValues.password);
    }
  };

  const validate = (values) => {
    const errors = {};
    if (!values.username) {
      errors.username = "Username is required!";
    }
    if (!values.password) {
      errors.password = "Password is required!";
    } else if (values.password.length < 4) {
      errors.password = "Password must be more than 4 characters";
    } else if (values.password.length > 10) {
      errors.password = "Password cannot exceed more than 10 characters";
    }
    return errors;
  };

  return (
    <div style={{ width: '100%', marginTop: '15px' }} className="container">
      <form onSubmit={handleSubmit}>
        <h1 style={{ textAlign: 'center', color:'white' }}>Вход</h1>
        <div className="ui divider"></div>
        <div className="ui form">
          <div className="field">
            <InputGroup style={{ maxWidth: '400px' }} className="mb-3 w-75 mx-auto">
              <InputGroup.Text>Логин</InputGroup.Text>
              <Form.Control
                type="text"
                name="username"
                value={formValues.username}
                onChange={handleChange}
              />
            </InputGroup>
            <InputGroup style={{ maxWidth: '400px' }} className="w-75 mx-auto">
              <InputGroup.Text>Пароль</InputGroup.Text>
              <Form.Control
                type="password"
                name="password"
                value={formValues.password}
                onChange={handleChange}
              />
            </InputGroup>
          </div>
          <p>{formErrors.password}</p>
        </div>
        <div className="field">
          <InputGroup style={{ maxWidth: '400px' }} className="w-75 mx-auto ">
            <InputGroup.Text>Запомнить пароль</InputGroup.Text>
            <InputGroup.Checkbox
              aria-label=""
              type="checkbox"
              name="rememberMe"
              checked={rememberMe}
              onChange={handleRememberMe}
            />
          </InputGroup>
        </div>
        <div style={{ textAlign: 'center', marginTop: '20px' }}>
          <button type="submit" className="btn btn-light">Войти</button>
        </div>
      </form>
    </div>
  );
}

export default Login;
