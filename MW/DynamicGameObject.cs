﻿using System;
using static NFSScript.Core.GameMemory;
using Addrs = NFSScript.Core.MWAddresses;
using NFSScript.Math;

namespace NFSScript.MW
{
    /// <summary>
    /// A class that represents a dynamic (physics) game object in the game world.
    /// </summary>
    public class DynamicGameObject : EAGLPhysicsObject
    {
        /// <summary>
        /// Returns the player's car dynamic game object.
        /// </summary>
        public static DynamicGameObject Player
        {
            get { return new DynamicGameObject(0); }
        }

        private int offset = 0;

        /// <summary>
        /// Dynamic game object gravity values.
        /// </summary>
        public override Vector3 GravityValues
        {
            get
            {
                float x = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_POS_X + offset + 30);
                float y = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_POS_Y + offset + 30);
                float z = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_POS_Z + offset + 30);

                return new Vector3(x, y, z);
            }
            set
            {
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_POS_X + offset + 30, value.x);
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_POS_Y + offset + 30, value.y);
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_POS_Z + offset + 30, value.z);
            }
        }

        /// <summary>
        /// The position of the defined dynamic object ID.
        /// </summary>
        public override Vector3 Position
        {
            get
            {
                int addr = (int)memory.getBaseAddress;
                float x = memory.ReadFloat((IntPtr)addr + Addrs.PlayerAddrs.STATIC_PLAYER_POS_X + offset);
                float y = memory.ReadFloat((IntPtr)addr + Addrs.PlayerAddrs.STATIC_PLAYER_POS_Y + offset);
                float z = memory.ReadFloat((IntPtr)addr + Addrs.PlayerAddrs.STATIC_PLAYER_POS_Z + offset);

                return new Vector3(x, y, z);
            }
            set
            {
                int addr = (int)memory.getBaseAddress;
                memory.WriteFloat((IntPtr)addr + Addrs.PlayerAddrs.STATIC_PLAYER_POS_X + offset, value.x);
                memory.WriteFloat((IntPtr)addr + Addrs.PlayerAddrs.STATIC_PLAYER_POS_Y + offset, value.y);
                memory.WriteFloat((IntPtr)addr + Addrs.PlayerAddrs.STATIC_PLAYER_POS_Z + offset, value.z);
            }
        }

        /// <summary>
        /// The rotation of the defined dynamic object ID.
        /// </summary>
        public override Quaternion Rotation
        {
            get
            {
                float x = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset);
                float y = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_Y_ROT + offset);
                float z = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_Z_ROT + offset);
                float w = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_W_ROT + offset);

                return new Quaternion(x, y, z, w);
            }
            set
            {
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset, value.x);
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset, value.y);
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset, value.z);
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset, value.w);
            }
        }

        /// <summary>
        /// The rotation axis of the dynamic object.
        /// </summary>
        public override Vector3 RotationAxis
        {
            get
            {
                float x = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset + 0x20);
                float y = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset + 0x24);
                float z = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset + 0x28);

                return new Vector3(x, y, z);
            }
            set
            {
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset + 0x20, value.x);
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset + 0x24, value.y);
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset + 0x28, value.z);
            }
        }

        /// <summary>
        /// The velocity direction of the dynamic object.
        /// </summary>
        public override Vector3 VelocityDirection
        {
            get
            {
                float x = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset + 0xF0);
                float y = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset + 0xF4);
                float z = memory.ReadFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset + 0xF8);

                return new Vector3(x, y, z);
            }
            set
            {
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset + 0xF0, value.x);
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset + 0xF4, value.y);
                memory.WriteFloat((IntPtr)Addrs.PlayerAddrs.STATIC_PLAYER_X_ROT + offset + 0xF8, value.z);
            }
        }

        /// <summary>
        /// The ID of the dynamic object that the class will effect, an ID bigger than 32 will probably crash the game.
        /// </summary>
        public override byte ID { get; set; }

        /// <summary>
        /// Instantiate a dynamic game object class by ID.
        /// </summary>
        /// <param name="ID">The ID of the car in the world, an ID bigger than 32 will probably crash the game.</param>
        public DynamicGameObject(byte ID)
        {
            this.ID = ID;
        }

        private int GetOffset(byte ID)
        {
            int offset = 0;
            for (int i = 0; i < ID; i++)
            {
                offset = offset + Addrs.GenericAddrs.POINTER_CAR_OFFSET;
            }

            return offset;
        }
    }
}
