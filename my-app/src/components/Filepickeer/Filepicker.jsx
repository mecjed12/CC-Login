import React from 'react';
import './Filepicker.css';
import axios from 'axios';
import Fileinput from '../input/Fileinput';
import Dropdown from '../Dropdown/Dropdown';
import Fileinput2 from '../input/FIleinput2';

export default class Filepicker extends React.Component {
    constructor(props) {
        super(props);
        this.getPerson()
        this.getCursor()
        this.state = {
            selectFile: null,
            isVisible: true,
            persons: [],
            course: [],
            
        }

    }
    person = [];
    getPerson() {
        var xhttp = new XMLHttpRequest();
        axios.get("http://192.168.0.94:8017/application/properties/person").then(res => {
            this.person = res.data
            this.person.forEach(option => {
               

            })
            this.setState({
                persons: this.person
            })
            console.log(this.person)
        }).catch(err => console.log(err))
    }
    curosr = [];
    getCursor() {
        var xhttp = new XMLHttpRequest();
        axios.get("http://192.168.0.94:8017/application/properties/course").then(res => {
            this.curosr = res.data
            this.curosr.forEach(option => {
               
            })
           this.setState({
                course: this.curosr
           })
            console.log(this.curosr)
        }).catch(err => console.log(err))
    }

    onChangeHandler = event => {
        this.setState({
            selectFile: event.target.files[0],
            loaded: 0,

        }
        );

    }
    onClickHandler = (config) => {
        if (!this.state.selectFile) {
            alert(" bitte geben die die file ein")
            return
        }
        const data = new FormData()
        data.append('file', this.state.selectFile);
        data.append('config', JSON.stringify(config))
        axios.post("http://localhost:8000/upload", data, {
        })
            .then(res => {
            })
    }
    switchsite() {
        if (!this.state.isVisible) {
            return <Fileinput2 />
        } else {
            if (this.state.persons.length > 0) {
                return <Fileinput personFields={this.state.persons} />
            } else {
                return null
            }
        }
    }

    toggleClass = (selection) => {
        this.setState({
            isVisible: selection
        })
        
    }


    render() {
        return (
            <div className="file-container">
                <div className="upload-container">
                    <label>Bitte geben sie Ihre Datei ein!</label>
                    <input className="upload" type="file" name="file" onChange={this.onChangeHandler} />
                </div>
                <Dropdown toggleClass={this.toggleClass} />
                <div className="input-switch">
                    {this.switchsite()}
                    {/* <Fileinput upload={this.onClickHandler} /> */}
                </div>
            </div>
        )
    }
}