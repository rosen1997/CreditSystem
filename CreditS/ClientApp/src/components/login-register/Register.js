import React, { Component } from 'react';

export class Register extends Component {


    constructor(props) {
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    onSubmit() {
        var firstName = document.getElementById('fN').value;
        var lastName = document.getElementById('lN').value;
        var phoneNum = document.getElementById('pN').value;
        var userName = document.getElementById('uN').value;
        var passWord = document.getElementById('pp').value;
    }


    render() {
        return (
            <div>
                <h1>Sing Up</h1>
                <div className="form-wrapper">
                    <form className="forms-lr" onSubmit={this.onSubmit}>
                        <label>
                            First Name:
                            <input type="text" id="fN" />
                        </label>
                        <label>
                            Last Name:
                            <input type="text" id="lN" />
                        </label>
                        <label>
                            Phone Number:
                            <input type="tel" id="pN"/>
                        </label>
                        <label>
                            User Name:
                            <input type="text" id="uN" />
                        </label>
                        <label>
                            Password:
                            <input type="password" id="pp"/>
                        </label>
                        <input className="submit-btn" type="submit" onClick={this.onSubmit} value="Sing Up" />
                    </form>
                </div>
            </div>
        );
    }
}