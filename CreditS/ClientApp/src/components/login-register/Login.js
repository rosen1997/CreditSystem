import React, { Component } from 'react';

export class Login extends Component {
    

    constructor(props) {
        super(props);
        
    }




    render() {
        return (
            <div>
                    <h1>Log In</h1>
                <div className="form-wrapper">
                    <form className="forms-lr" onSubmit={this.handleSubmit}>
                        <label>User Name:
                            <input type="text" />
                        </label>
                        <label>Password:
                            <input type="password" />
                        </label>
                        <p>Don't have an account?<a href="/register"> Sign up.</a> </p>
                        <input className="submit-btn" type="submit" value="Log In" />
                    </form>
                </div>
            </div>
        );
    }
}