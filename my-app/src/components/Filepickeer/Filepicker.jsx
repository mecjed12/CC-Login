import React from 'react';
import './Filepicker.css';
import axios from 'axios';
import Fileinput from '../input/Fileinput';
import Dropdown from '../Dropdown/Dropdown';

export default class Filepicker extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            selectFile: null,
            name: null
        }
    }

    onChangeHandler = event => {
        this.setState({
            selectFile: event.target.files[0],
            loaded: 0,
        }
        );
    }
    onClickHandler = (properties) => {
        // if (!this.state.selectFile) {
        //     alert(" bitte geben die die file ein")
        //     return
        // }
        const data = new FormData()
        data.append('file', this.state.selectFile);
        data.append('properties', JSON.stringify(properties))
        console.log(properties)
        axios.post("http://192.168.0.94:8017/application/" + this.state.name, data, {
        })

            .then(res => {
                console.log(res)
            }).catch(err => console.log(err.response))
    }
    switchsite() {
        if (this.state.name != null) {
            return <Fileinput name={this.state.name} upload={this.onClickHandler} />
        }
    }
    toggleClass = (selection) => {
        this.setState({
            name: selection,
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
                </div>
            </div>
        )
    }
}