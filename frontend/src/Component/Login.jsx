import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const Login = () => {
    const [userName, setUserName] = useState('');
    const [userId, setUserId] = useState(0);
    const [loggedIn, setLoggedIn] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        console.log("userId - ", userId);
    }, [userId]);

    
    const login = async () => {
        try {
            const response = await axios.post('http://localhost:5109/api/Users', { userName });
            console.log(response.data);
            setUserId(response.data.userId);

            console.log("userId - ", userId);
            setLoggedIn(true);
            console.log(loggedIn);
            if (response.status === 201) {
                navigate('/alltest');
            }
        } catch (error) {
            console.error(error);
        }
    };
    const handleInputChange = (event) => {
        setUserName(event.target.value);
    };
    useEffect(() => {
        console.log("userId - ", userId);
    }, [userId]);


    return (
        <div>
            <div>Login</div>
            <form>
                <div className="form-outline mb-4">
                    <input
                        type="text"
                        id="form2Example1"
                        className="form-control"
                        value={userName}
                        onChange={handleInputChange}
                    />
                    <label className="form-label" htmlFor="form2Example1">Name</label>
                </div>
                <button
                    type="button"
                    className="btn btn-primary btn-block mb-4"
                    onClick={login}
                >
                    Login
                </button>
            </form>
            {/* {userId !== null && <TestPage userId={userId} />} */}


        </div>
    );
};



export default Login;
