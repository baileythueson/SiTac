# SiTac: Tactical Situational Awareness Suite

![Build Status](https://img.shields.io/github/actions/workflow/status/baileythueson/SiTac/build.yml?label=Build&logo=github)
![Platform](https://img.shields.io/badge/Platform-Windows%20(WPF)-0078D7)
![Standard](https://img.shields.io/badge/Standard-Cursor%20on%20Target%20(CoT)-orange)
[![Trello](https://img.shields.io/badge/Roadmap-Trello-%230052CC?logo=trello)](https://trello.com/b/vcokoV9t/sitac)

**SiTac** (Sim Tactical) is a distributed Command & Control (C2) system designed to visualize real-time telemetry from remote assets. Built on the **.NET 10** ecosystem, it implements the **Cursor on Target (CoT)** interoperability standard to maintain Common Operational Pictures (COP) across disparate nodes.

The suite simulates a "System of Systems" architecture, decoupling the hardware simulation from the visualization layer via UDP multicast networking.

---

## 🏗 Architecture

The solution follows a Clean Architecture approach, organized into a monorepo with shared kernel logic:

* **`SiTacLib` (Core):** A shared standard library containing the CoT data models, XML serialization logic, and networking primitives. Ensures strict schema validation between Sender and Receiver.
* **`SiTacSim` (The Edge):** A console-based asset simulator. It generates high-frequency telemetry (GPS, altitude, battery, velocity) for autonomous agents and broadcasts CoT events via UDP.
* **`SiTac` (The Dashboard):** A high-performance WPF application utilizing **MVVM**. It listens for incoming packets, deserializes the XML payload, and renders the assets on a geospatial display in real-time.

---

## 🎯 Key Features

### 1. Interoperability (Cursor on Target)
Implements the MIL-STD/Event Schema for CoT.
* **Event Generation:** Generates standard `a-f-A-M-F-Q` (Friendly/Air/Mil/Drone) atomic events.
* **Extensible Payloads:** Custom `<detail>` implementation for tracking extended metrics (Fuel, Signal Strength) while preserving schema compliance.

### 2. High-Performance Networking
* **UDP Multicast:** Utilizes `System.Net.Sockets` for fire-and-forget telemetry streams, mimicking low-bandwidth tactical radio environments.
